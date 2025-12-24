using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScanManager : MonoBehaviour
{
    public Button ExitButton;
    
    void Start()
    {
        if (ExitButton != null)
        {
            ExitButton.onClick.AddListener(OnExitButtonClicked);
        }
        else
        {
            Debug.LogError("ExitButton is not assigned in ScanManager!");
        }
    }

    // Update is called once per frame
    public void OnExitButtonClicked()
    {
        Debug.Log("Exit Button Pressed");
        SceneManager.LoadScene("HomeScene");
    }


}
