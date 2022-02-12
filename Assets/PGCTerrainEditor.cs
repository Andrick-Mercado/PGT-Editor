using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PGCTerrain))]
[CanEditMultipleObjects]
public class PGCTerrainEditor : Editor
{
    SerializedProperty SizeOfTerrain;

    //SerializedProperty Width;

    //SerializedProperty Depth;

    SerializedProperty Scale;

    SerializedProperty SelectAlgorithm;

    //SerializedProperty AutoUpdateOnAnyChange;


    private string currentValue;
    private bool isRunning = false;

    void OnEnable()
    {
        SizeOfTerrain = serializedObject.FindProperty("_size");
        //Width = serializedObject.FindProperty("_width");
        //Depth = serializedObject.FindProperty("_depth");
        Scale = serializedObject.FindProperty("frequency");
        SelectAlgorithm = serializedObject.FindProperty("SelectAlgorithm");
        //AutoUpdateOnAnyChange = serializedObject.FindProperty("AutoUpdateOnAnyChange");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        PGCTerrain terrain = (PGCTerrain)target;

        
        EditorGUILayout.IntSlider(SizeOfTerrain, 0, 5);
        currentValue = CalculateDimensions(SizeOfTerrain.intValue);
        EditorGUILayout.LabelField("Size of terrain HxW: " + currentValue + "x"+ currentValue);


        EditorGUILayout.Space();

        ////EditorGUILayout.PropertyField(Width);
        ////EditorGUILayout.LabelField("Width of terrain");
        ////EditorGUILayout.Space();

        ////EditorGUILayout.PropertyField(Depth);
        //EditorGUILayout.IntSlider(Depth, -20, 20 );
        //EditorGUILayout.LabelField("Depth of terrain");
        //EditorGUILayout.Space();

        EditorGUILayout.Slider(Scale, 0f, 100f);
        EditorGUILayout.LabelField("Frequency of Terrain");
        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(SelectAlgorithm);
        EditorGUILayout.LabelField("Which algorithm to use for the terrain");
        EditorGUILayout.Space();

        //EditorGUILayout.PropertyField(AutoUpdateOnAnyChange);
        //EditorGUILayout.LabelField("Calculate every change above (may slow down performance)");
        //EditorGUILayout.Space();

        

        serializedObject.ApplyModifiedProperties();
    }

    string CalculateDimensions(int cur)
    {
        currentValue = cur != 0 ? ((int)Mathf.Pow(2, cur + 4)).ToString() : "0";
        return currentValue;
    }

    

    
}
