using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class BuildScript 
{
    
    public static void BuildWindows()
    {
        string path = "Builds/Windows/MyGame.exe";

        BuildPipeline.BuildPlayer(
            EditorBuildSettings.scenes,
            path,
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }
    
}
