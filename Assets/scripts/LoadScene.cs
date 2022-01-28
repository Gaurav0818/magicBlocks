using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadLvl(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }
}
