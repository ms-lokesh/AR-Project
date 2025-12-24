using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneOpener
{
    [MenuItem("TexAR/Open HomeScene")]
    public static void OpenHomeScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/HomeScene.unity");
    }

    [MenuItem("TexAR/Open SampleScene (AR)")]
    public static void OpenSampleScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity");
    }

    [MenuItem("TexAR/Open LogInScene")]
    public static void OpenLogInScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/LogInScene.unity");
    }

    [MenuItem("TexAR/Show All Assets in Project")]
    public static void ShowAllAssets()
    {
        // Clear search in Project window
        var projectBrowser = typeof(Editor).Assembly.GetType("UnityEditor.ProjectBrowser");
        var window = EditorWindow.GetWindow(projectBrowser);
        var searchField = projectBrowser.GetField("m_SearchFilter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (searchField != null)
        {
            var searchFilter = searchField.GetValue(window);
            searchFilter.GetType().GetMethod("ClearSearch").Invoke(searchFilter, null);
            window.Repaint();
        }
    }
}
