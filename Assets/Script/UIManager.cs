using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text sText;
    public GameObject titleScreen;
    public GameObject readyScreen;
    public GameObject gameOverScreen;
    public GameObject scoreUI;

    public void UpdateScore(int score)
    {
        sText.text = score.ToString();
    }

    public void ShowStart()
    {
        titleScreen.SetActive(true);
        readyScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        scoreUI.SetActive(false);
    }

    public void HideStart()
    {
        titleScreen.SetActive(false);
    }

    public void ShowReady()
    {
        titleScreen.SetActive(false);
        readyScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void HideReady()
    {
        readyScreen.SetActive(false);
        scoreUI.SetActive(true);
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }


}
