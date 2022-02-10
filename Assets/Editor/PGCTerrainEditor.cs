using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PGCTerrain))]
public class PGCTerrainEditor : Editor
{
    SerializedProperty Height;

    SerializedProperty Width;

    SerializedProperty Depth;

    SerializedProperty Scale;

    SerializedProperty SelectAlgorithm;

    SerializedProperty AutoUpdateOnAnyChange;



    void OnEnable()
    {
        Height = serializedObject.FindProperty("_height");
        Width = serializedObject.FindProperty("_width");
        Depth = serializedObject.FindProperty("_depth");
        Scale = serializedObject.FindProperty("scale");
        SelectAlgorithm = serializedObject.FindProperty("SelectAlgorithm");
        AutoUpdateOnAnyChange = serializedObject.FindProperty("AutoUpdateOnAnyChange");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(Height);
        EditorGUILayout.PropertyField(Width);
        EditorGUILayout.PropertyField(Depth);
        EditorGUILayout.PropertyField(Scale);
        EditorGUILayout.PropertyField(SelectAlgorithm);
        EditorGUILayout.PropertyField(AutoUpdateOnAnyChange);

        serializedObject.ApplyModifiedProperties();
    }
}
