using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public Button ScanButton;
    public Button QuitButton;
    public Button GlassButton;
    
    void Start()
    {
        if (ScanButton != null)
        {
            ScanButton.onClick.AddListener(OnScanButtonClicked);
        }
        else
        {
            Debug.LogError("ScanButton is not assigned in HomeManager!");
        }
        
        if (QuitButton != null)
        {
            QuitButton.onClick.AddListener(OnQuitButtonClicked);
        }
        else
        {
            Debug.LogError("QuitButton is not assigned in HomeManager!");
        }
        
        if (GlassButton != null)
        {
            GlassButton.onClick.AddListener(OnGlassButtonClicked);
        }
        else
        {
            Debug.LogError("GlassButton is not assigned in HomeManager!");
        }
    }

    // Update is called once per frame
    public void OnScanButtonClicked()
    {
        Debug.Log("Scan Button Pressed");
        SceneManager.LoadScene("SampleScene");
    }

    public void OnQuitButtonClicked()
    {
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }

    public void OnGlassButtonClicked()
    {
        Debug.Log("Glass/Login Button Pressed");
        SceneManager.LoadScene("LogInScene");
    }
}
