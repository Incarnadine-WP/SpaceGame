using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    [HideInInspector] public GameObject pauseMenuUI;
    [HideInInspector] public GameObject gameOverMenu;
    [HideInInspector] public GameObject levelCompleteMenu;

    public static bool gameIsPaused = false;
    public bool isGameActive;

    private AudioSource _audio;

    private void Start()
    {
        _audio = FindObjectOfType<AudioSource>().GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        gameOverMenu.SetActive(false);
        _audio.Play();
    }

    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0.2f;
        gameOverMenu.SetActive(true);
        _audio.Stop();
    }

    public void LevelComplete()
    {
        levelCompleteMenu.SetActive(true);
        isGameActive = false;
        Time.timeScale = 0.2f;
        _audio.Stop();
    }
}
