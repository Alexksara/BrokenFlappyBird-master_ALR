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

    //Summary
    //enables ttitle screen and disables all others
    public void ShowStart()
    {
        titleScreen.SetActive(true);
        readyScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        scoreUI.SetActive(false);
    }

    //Summary
    // hides start screen
    public void HideStart()
    {
        titleScreen.SetActive(false);
    }

    //Summary
    // shows ready screen and disables other screens
    public void ShowReady()
    {
        titleScreen.SetActive(false);
        readyScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    //Summary
    //hides ready screen
    public void HideReady()
    {
        readyScreen.SetActive(false);
        scoreUI.SetActive(true);
    }
    //Summary
    // shows game over screen
    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }


}
