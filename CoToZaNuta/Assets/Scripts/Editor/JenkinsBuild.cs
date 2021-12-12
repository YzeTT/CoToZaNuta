using UnityEditor;
using UnityEngine;

public class JenkinsBuild
{
    public static void PerformBuild()
    {
        string[] defaultScene = {"Assets/Scenes/MainScene.unity"};
        BuildPipeline.BuildPlayer(defaultScene, "./builds/game.x86_64",
            BuildTarget.Android, BuildOptions.None);
    }
    
    public static void Jenkins()
    {
        Debug.Log("afw[awkf[awfawfwa");
    }
}