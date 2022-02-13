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

    SerializedProperty Depth;

    SerializedProperty Scale;

    SerializedProperty SelectAlgorithm;

    //SerializedProperty AutoUpdateOnAnyChange;

    SerializedProperty randomHeightRange;


    private string currentValue;
    private bool showRandom = false;
    private bool showCustom = false;

    void OnEnable()
    {
        SizeOfTerrain = serializedObject.FindProperty("_size");
        //Width = serializedObject.FindProperty("_width");
        Depth = serializedObject.FindProperty("_depth");
        Scale = serializedObject.FindProperty("frequency");
        SelectAlgorithm = serializedObject.FindProperty("SelectAlgorithm");
        //AutoUpdateOnAnyChange = serializedObject.FindProperty("AutoUpdateOnAnyChange");
        randomHeightRange = serializedObject.FindProperty("randomHeightRange");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        PGCTerrain terrain = (PGCTerrain)target;

        showCustom = EditorGUILayout.Foldout(showCustom, "Custom");

        if (showCustom)
        {
            EditorGUILayout.IntSlider(SizeOfTerrain, 0, 5);
            currentValue = CalculateDimensions(SizeOfTerrain.intValue);
            EditorGUILayout.LabelField("Size of terrain HxW: " + currentValue + "x" + currentValue);


            EditorGUILayout.Space();

            EditorGUILayout.Slider(Scale, -100f, 100f);
            EditorGUILayout.LabelField("Frequency of Terrain");
            EditorGUILayout.Space();

            EditorGUILayout.IntSlider(Depth, -100, 100);
            EditorGUILayout.LabelField("Depth of Terrain");
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(SelectAlgorithm);
            EditorGUILayout.LabelField("Which algorithm to use for the terrain");
            EditorGUILayout.Space();

            if (GUILayout.Button("Run Changes"))
            {
                terrain.GenerateTerrainData(false);
            }
        }

        showRandom = EditorGUILayout.Foldout(showRandom, "Random");

        if (showRandom)
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            GUILayout.Label("Set Heights Between Random Values", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(randomHeightRange);
            if (GUILayout.Button("Random Heights"))
            {
                terrain.GenerateTerrainData(true);
            }
        }

        serializedObject.ApplyModifiedProperties();
    }

    string CalculateDimensions(int cur)
    {
        currentValue = cur != 0 ? ((int)Mathf.Pow(2, cur + 4)).ToString() : "0";
        return currentValue;
    }

    

    
}
