using UnityEngine;
using TMPro;

public class GameFlowController : MonoBehaviour
{
    float enemySpeedMultiplyer = 1;
    [Range(0.01f , 0.2f)]
    public float increaseSpeedBy = 0.1f;

    Enemy enemy;
    int score;
    [Range(1,3)]
    public int Difficulty;

    public GameObject endPanel;
    public GameObject normalPanel;

    public TMP_Text text;
    public TMP_Text endText;

    private void Start()
    {
        normalPanel.SetActive(true);
        endPanel.SetActive(false);

        if (FindObjectOfType<DontDestroyScript>())
            Difficulty = FindObjectOfType<DontDestroyScript>().GameMode;

        if (Difficulty == 1)
        {
            increaseSpeedBy = 0.03f;
        }
        else if(Difficulty == 2)
        {
            increaseSpeedBy = 0.08f;
        }
        else 
        {
            increaseSpeedBy = 0.15f;
        }

        enemy = FindObjectOfType<Enemy>();
        score = 0;
        text.text = score.ToString();
    }

    public void IncreseEnemySpeed()
    {
        enemySpeedMultiplyer += increaseSpeedBy;
        enemy.speedMultiplyer = enemySpeedMultiplyer;
    }

    public void IncreaseScore(int value)
    {
        score += value;
        text.text = score.ToString();
    }

    public void EndGame()
    {
        endPanel.SetActive(true);
        normalPanel.SetActive(false);

        endText.text = score.ToString();
    }

}
