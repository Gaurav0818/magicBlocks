using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    public int GameMode = 1;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void EasyMode()
    {
        GameMode = 1;
        CallSceneManager();
    }

    public void NormalMode()
    {
        GameMode = 2;
        CallSceneManager();
    }

    public void HardMode()
    {
        GameMode = 3;
        CallSceneManager();
    }

    private void CallSceneManager()
    {
        FindObjectOfType<LoadScene>().LoadLvl(1);
    }
    
}
