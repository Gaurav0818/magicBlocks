using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject modePanel;
    private void Start()
    {
        menuPanel.SetActive(true);
        modePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetMenuActive();
        }   
    }

    public void SetModeActive()
    {
        modePanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void SetMenuActive()
    {
        modePanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
