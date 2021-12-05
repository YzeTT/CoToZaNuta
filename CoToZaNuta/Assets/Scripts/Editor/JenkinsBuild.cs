using UnityEditor;

public class JenkinsBuild 
{
    static void PerformBuild()
    {
        string[] defaultScene = {"Assets/_Project/Scenes/MainScene.unity"};
        BuildPipeline.BuildPlayer(defaultScene, "./builds/game.x86_64",
            BuildTarget.Android, BuildOptions.None);
    }
}