using System;
using System.Collections.Generic;
using UnityEngine;

public class PGCTerrain : MonoBehaviour
{
    [SerializeField]
    private int _height = 128;

    [SerializeField]
    private int _width = 128;

    [SerializeField]
    private int _depth = 20;

    [SerializeField]
    private float scale = 20f;


    [SerializeField]
    private MyEnum SelectAlgorithm = new MyEnum();
    public enum MyEnum
    {
        Sin,
        Cos,
        Perlin
    };

    [SerializeField]
    private bool AutoUpdateOnChange = false;

    private Terrain _currentTerrain;

    private bool _hasChanged;
    private string _previous;

    private void Start()
    {
        _currentTerrain = GetComponent<Terrain>();
        _currentTerrain.terrainData = GenerateTerrainData(_currentTerrain.terrainData);
    }

    void Update()
    {
        if (!_hasChanged || AutoUpdateOnChange)
        {
            _currentTerrain.terrainData = GenerateTerrainData(_currentTerrain.terrainData);
        }
        else if (!SelectAlgorithm.ToString().Equals(_previous))
        {
            Debug.Log("has runned?");
            _hasChanged = false;
        }
        
}

    TerrainData GenerateTerrainData(TerrainData terrainData)
    {
        terrainData.heightmapResolution = _width + 1;

        terrainData.size = new Vector3(_width, _depth, _height );

        terrainData.SetHeights(0,0,GenerateHeights());

        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[_width, _height];

        for(int x = 0; x< _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }

    float CalculateHeight (int x, int y)
    {
        float xCoord = (float) x / _width * scale;
        float yCoord = (float) y / _height * scale;

        string currentString = SelectAlgorithm.ToString();

        if (currentString.Equals("Sin"))
        {
            _hasChanged = true;
            _previous = "Sin";
            return Mathf.Sin(xCoord) + Mathf.Sin(yCoord);
        }
        else if (currentString.Equals("Cos"))
        {
            _hasChanged = true;
            _previous = "Cos";
            return Mathf.Cos(xCoord) * Mathf.Cos(yCoord);
        }
        else if (currentString.Equals("Perlin"))
        {
            _hasChanged = true;
            _previous = "Perlin";
            return Mathf.PerlinNoise(xCoord, yCoord);
        }
        else//not possible in current setup
            return xCoord + yCoord;
    }
}
