using UnityEditor;
using UnityEngine;

public class BuildScript
{
    static void PerformBuild()
    {
        string[] defaultScene = {"Assets/_Project/Scenes/MainScene.unity"};
        BuildPipeline.BuildPlayer(defaultScene, "./MyGame/game.x86_64",
            BuildTarget.StandaloneWindows64, BuildOptions.None);
    }
}
    
