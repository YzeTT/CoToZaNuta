﻿using UnityEditor;
using UnityEngine;

public class JenkinsBuild 
{
    static void PerformBuild()
    {
        string[] defaultScene = {"Assets/_Project/Scenes/MainScene.unity"};
        Debug.Log("fffffffffffff");
        BuildPipeline.BuildPlayer(defaultScene, "./game.x86_64",
            BuildTarget.Android, BuildOptions.None);
    }
}