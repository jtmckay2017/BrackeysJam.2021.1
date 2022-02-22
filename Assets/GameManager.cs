using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }

    private static GameManager _instance;

    public bool isTimedMode = false;
    public bool gameOver = false;
    public bool gameOverHandled = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Update()
    {
        if (gameOver && !gameOverHandled)
        {
            HandleGameOver();
            gameOverHandled = true;
        }
    }

    public void HandleGameOver()
    {
        SceneManager.LoadScene(0);
    }
}
