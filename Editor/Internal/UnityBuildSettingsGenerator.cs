﻿using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.IO;

namespace UnityBuild
{

public static class UnityBuildSettingsGenerator
{
    //static UnityBuildSettingsGenerator()
    //{
    //    Type ti = typeof(BuildSettings);

    //    foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
    //    {
    //        foreach (Type t in asm.GetTypes())
    //        {
    //            if (ti.IsAssignableFrom(t) && ti != t)
    //            {
    //                return;
    //            }
    //        }
    //    }

    //    // No implementation of BuildSettings found, so generate one.
    //    GenerateBuildSettings();
    //}

    [MenuItem("Edit/Generate BuildSettings")]
    public static void GenerateBuildSettings()
    {
        string directory = EditorUtility.OpenFolderPanel("Choose location for ProjectBuildSettings.cs (MUST BE AN EDITOR DIRECTORY)", Application.dataPath, "");

        // If user cancelled, we can't do anything.
        if (string.IsNullOrEmpty(directory))
        {
            return;
        }
        else if (!directory.Contains(Path.AltDirectorySeparatorChar + "Editor") && !directory.Contains(Path.DirectorySeparatorChar + "Editor" + Path.DirectorySeparatorChar))
        {
            Debug.LogError("BuildSettings file must be in an Editor directory/sub-directory");
            return;
        }

        string filePath = Path.Combine(directory, "ProjectBuildSettings.cs");

        string templateFilePath = string.Empty;
        foreach (var file in Directory.GetFiles(Application.dataPath, "*.txt", SearchOption.AllDirectories))
        {
            if (Path.GetFileNameWithoutExtension(file) == "BuildSettingsTemplate")
            {
                templateFilePath = file;
                break;
            }
        }

        File.WriteAllText(filePath, File.ReadAllText(templateFilePath));

        AssetDatabase.Refresh();
    }
}

}