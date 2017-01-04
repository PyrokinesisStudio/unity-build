﻿using System;
using UnityEditor;
using UnityEngine;

namespace SuperSystems.UnityBuild
{

[CustomPropertyDrawer(typeof(ProductParameters))]
public class ProductParametersDrawer : PropertyDrawer
{
    private bool show = true;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, GUIContent.none, property);

        EditorGUILayout.BeginHorizontal();
        UnityBuildGUIUtility.DropdownHeader("Product Parameters", ref show, GUILayout.ExpandWidth(true));
        UnityBuildGUIUtility.HelpButton("Parameter-Details#Product-Parameters");
        EditorGUILayout.EndHorizontal();

        if (show)
        {
            EditorGUILayout.BeginVertical(UnityBuildGUIUtility.dropdownContentStyle);

            EditorGUILayout.PropertyField(property.FindPropertyRelative("version"));

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(property.FindPropertyRelative("lastGeneratedVersion"));
            EditorGUI.EndDisabledGroup();

            SerializedProperty autoGenerate = property.FindPropertyRelative("autoGenerate");
            autoGenerate.boolValue = EditorGUILayout.ToggleLeft("Auto-Generate Version", autoGenerate.boolValue);

            EditorGUILayout.PropertyField(property.FindPropertyRelative("buildCounter"));

            if (GUILayout.Button("Reset Build Counter", GUILayout.ExpandWidth(true)))
            {
                property.FindPropertyRelative("buildCounter").intValue = 0;
            }

            if (!autoGenerate.boolValue && GUILayout.Button("Generate Version String Now", GUILayout.ExpandWidth(true)))
            {
                BuildProject.GenerateVersionString(BuildSettings.productParameters, DateTime.Now);
            }

            property.serializedObject.ApplyModifiedProperties();

            EditorGUILayout.EndVertical();
        }

        EditorGUI.EndProperty();
    }
}

}