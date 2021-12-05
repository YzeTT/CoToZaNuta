using UnityEditor;

public class BuildScript
{
    static void PerformBuild()
    {
        string[] defaultScene = {"Assets/_Project/Scenes/MainScene.unity"};
        BuildPipeline.BuildPlayer(defaultScene, "./builds/game.x86_64",
            BuildTarget.StandaloneWindows64, BuildOptions.None);
    }
}
    
