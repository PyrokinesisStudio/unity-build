﻿using UnityEditor;

namespace SuperSystems.UnityBuild
{

[System.Serializable]
public class BuildOSX : BuildPlatform
{
    #region Constants

    private const string _name = "OSX";
    private const string _binaryNameFormat = "{0}.app";
    private const string _dataDirNameFormat = "{0}.app/Contents";
    private const BuildTargetGroup _targetGroup = BuildTargetGroup.Standalone;

    #endregion

    public BuildOSX()
    {
        enabled = false;
        platformName = _name;
        architectures = new BuildArchitecture[] { 
            new BuildArchitecture(BuildTarget.StandaloneOSXUniversal, "OSX Universal", true),
            new BuildArchitecture(BuildTarget.StandaloneOSXIntel, "OSX Intel", false),
            new BuildArchitecture(BuildTarget.StandaloneOSXIntel64, "OSX Intel64", false)
        };
    }
}

}