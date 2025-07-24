using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S_Instance;

    public Bird bird;
    public PipeSpawner pipeSpawner;
    public UIManager uiManager;

    private int M_score = 0;

    void Awake()
    {
        if (S_Instance != null && S_Instance != this)
        {
            Destroy(this);
        }
        else
        {
            S_Instance = this;
        }
        pipeSpawner.enabled = false;
    }

    void Start()
    {
        uiManager.ShowStart();
        bird.gameObject.SetActive(false);
    }

    //Summary
    //resets the scene

    public void ResetGame()
    {
        foreach(GameObject pipe in pipeSpawner.pipes)
        {
            Destroy(pipe.gameObject);
        }
        M_score = 0;
        uiManager.UpdateScore(M_score);

        uiManager.ShowStart();
        pipeSpawner.enabled = false;
        bird.ResetBird();
        bird.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    //Summary
    // prepares the ready screen telling the player how to paly
    public void ReadyGame()
    {
        uiManager.HideStart();
        uiManager.ShowReady();
        bird.ResetBird();
        bird.gameObject.SetActive(true);
    }

    //Summary
    //begins the game
    public void StartGame()
    {
        M_score = 0;
        uiManager.HideReady();
        pipeSpawner.enabled = true;
        bird.StartGame();
    }

    //Summary
    // ends game stopping time and calling game over
    public void GameOver()
    {
        Time.timeScale = 0f;
        uiManager.ShowGameOver();
    }
    //Summary
    //incriments score and updates UI
    public void IncreaseScore()
    {
        M_score++;
        uiManager.UpdateScore(M_score);
    }
}
