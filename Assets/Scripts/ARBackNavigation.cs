using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ARBackNavigation : MonoBehaviour
{
    public ARSession arSession;
    public string previousSceneName = "HomeScene";

    void Start()
    {
        if (arSession == null)
        {
            arSession = FindObjectOfType<ARSession>();
            if (arSession == null)
            {
                Debug.LogWarning("ARSession not found. AR session will not be reset on back navigation.");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Back button detected in AR Session. Navigating to " + previousSceneName);
            if (arSession != null)
            {
                arSession.Reset();
            }
            
            if (!string.IsNullOrEmpty(previousSceneName))
            {
                SceneManager.LoadScene(previousSceneName);
            }
            else
            {
                Debug.LogError("Previous scene name is empty!");
            }
        }
    }
}
