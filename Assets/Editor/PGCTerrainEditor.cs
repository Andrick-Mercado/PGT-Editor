using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PGCTerrain))]
public class PGCTerrainEditor : Editor
{
    SerializedProperty SizeOfTerrain;

    SerializedProperty Width;

    SerializedProperty Depth;

    SerializedProperty Scale;

    SerializedProperty SelectAlgorithm;

    SerializedProperty AutoUpdateOnAnyChange;



    void OnEnable()
    {
        SizeOfTerrain = serializedObject.FindProperty("_height");
        Width = serializedObject.FindProperty("_width");
        Depth = serializedObject.FindProperty("_depth");
        Scale = serializedObject.FindProperty("scale");
        SelectAlgorithm = serializedObject.FindProperty("SelectAlgorithm");
        AutoUpdateOnAnyChange = serializedObject.FindProperty("AutoUpdateOnAnyChange");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        
        //EditorGUILayout.PropertyField(Height);
        EditorGUILayout.IntSlider(SizeOfTerrain, 0, 10);
        EditorGUILayout.LabelField("Size of terrain HxW: " + Width.intValue + "x"+ Width.intValue);
        EditorGUILayout.Space();

        //EditorGUILayout.PropertyField(Width);
        //EditorGUILayout.LabelField("Width of terrain");
        //EditorGUILayout.Space();

        //EditorGUILayout.PropertyField(Depth);
        EditorGUILayout.IntSlider(Depth, -20, 20);
        EditorGUILayout.LabelField("Depth of terrain");
        EditorGUILayout.Space();

        EditorGUILayout.Slider(Scale, 0f, 100f);
        EditorGUILayout.LabelField("Frequency of Terrain");
        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(SelectAlgorithm);
        EditorGUILayout.LabelField("Which algorithm to use for the terrain");
        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(AutoUpdateOnAnyChange);
        EditorGUILayout.LabelField("Calculate every change above (may slow down performance)");
        EditorGUILayout.Space();

        serializedObject.ApplyModifiedProperties();
    }
}
