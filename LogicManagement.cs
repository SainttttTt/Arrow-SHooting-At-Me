using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class LogicManagement : MonoBehaviour
{
    public TimerTextScipr   TextForHighScore;
    public GameObject       YouLostCanvas;
    public GameObject       NewRecordScreenCanvas;
    public GameObject       GearCanvas;
    public GameObject[]     CanvasToEliminateWhenGearsOpenToAvoidBugs;
    public GameObject       baiter; //anEmptyGameObject
    
    public bool isPaused    = false;
    public bool GamesOver   = false;

    public TMP_Text         HighScoreText;
    public TextMeshProUGUI  HighScoreTextOfRecordScreenCanvas;
    public AudioSource      GameTheme;
    public Slider           sliderVolume;
    public CircleCollider2D ColliderOfPlayerToDisable;
    public Joystick         FloatingJoystick;
    
    private int actualScore = 0;
    private bool areGearsOpen = false;

    private void Start()
    {
        HighScoreText.text = "Highscore:\n" + PlayerPrefs.GetInt("HighScore", 0).ToString();
        GameTheme.Play();
        GameTheme.volume = PlayerPrefs.GetFloat("VolumeSaver", 0.2f);
        sliderVolume.value = GameTheme.volume;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && GamesOver == false && areGearsOpen == false) //i.e. only when the game is not in pause 
        {
            if (isPaused == false)
            {
                PauseGame();
                return;
            }
            if (isPaused == true)
            {
                unPauseGame();
                return;
            }
        }

    }

    public void EndGameScreen()
    {
        ColliderOfPlayerToDisable.enabled = false;
        GamesOver = true;
        actualScore = int.Parse(TextForHighScore.TimerText.text);
        TextForHighScore.TimerText.text = actualScore.ToString("0000");

        if (actualScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", actualScore);
            HighScoreTextOfRecordScreenCanvas.text = actualScore.ToString();
            NewRecordScreen();
            return;
        }

        if(NewRecordScreenCanvas.gameObject.activeInHierarchy == false)
            YouLostCanvas.SetActive(true);
    
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NewRecordScreen()
    {
        NewRecordScreenCanvas.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        GameTheme.Pause();
        Time.timeScale = 0;
        isPaused = true;
    }

    public void unPauseGame()
    {
        GameTheme.UnPause();
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    //outside
    bool LostScreenActive = false;
    bool RecordScreenActive = false;
    public void onGearBUttonPressed()
    {
        if (YouLostCanvas.activeInHierarchy)
        {
            LostScreenActive = true;
            YouLostCanvas.SetActive(false);
        }

        if (NewRecordScreenCanvas.activeInHierarchy)
        {
            RecordScreenActive = true;
            NewRecordScreenCanvas.SetActive(false);
        }

        if (!areGearsOpen)
        {
            areGearsOpen = true;
            GearCanvas.SetActive(true);
            PauseGame();
            return;
        }


        unPauseGame();
        if (LostScreenActive)
        {
            YouLostCanvas.SetActive(true);
            LostScreenActive = false;
        }
        if (RecordScreenActive)
        {
            NewRecordScreenCanvas.SetActive(true);
            RecordScreenActive = false;
        }
        FloatingJoystick.gameObject.SetActive(true);
        areGearsOpen = false;
        GearCanvas.SetActive(false);

        return;
    }

    public void setVolume()
    {
        GameTheme.volume = sliderVolume.value;
        PlayerPrefs.SetFloat("VolumeSaver",GameTheme.volume);
    }


    public void MenuButtonInGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Menu");
    }

}
