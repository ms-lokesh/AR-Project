using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServicesManager : MonoBehaviour
{
    public Button HomeButton;
    public Button ServicesButton;
    public Button ProfileButton;
    
    void Start()
    {
        if (HomeButton != null)
        {
            HomeButton.onClick.AddListener(OnHomeButtonClicked);
        }
        else
        {
            Debug.LogError("HomeButton is not assigned in ServicesManager!");
        }
        
        // Note: ServicesButton and ProfileButton are declared but not used
        // Consider implementing their functionality or removing them
    }

    // Update is called once per frame
    public void OnHomeButtonClicked()
    {
        Debug.Log("Home Button Pressed");
        SceneManager.LoadScene("HomeScene");
    }


}
