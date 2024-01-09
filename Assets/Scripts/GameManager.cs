using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject[] Spawners;
    public TMP_Text ScoreValue;
    public TMP_Text LivesValue;
    public Texture2D crosshair;
    public UIScript ui;

    private TargetType type;

    // CODE URIEL
    //public TMP_Text ScoreMultValue;

    private bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(crosshair, new Vector2(16f, 16f), CursorMode.Auto);
        EnabledSpawners();
    }

    // Update is called once per frame
    void Update()
    {
        // CODE URIEL
        //if (Settings.ScoreMultiplier.ToString() != ScoreMultValue.text && isPlaying)
        //{
        //    UpdateScore();
        //}

        if (Settings.Score.ToString() != ScoreValue.text && isPlaying)
        {
            UpdateScore();
        }
        if (Settings.PlayerLife.ToString() != LivesValue.text && isPlaying)
        {
            UpdateLife();
        }

        if (Settings.PlayerLife <= 0 && isPlaying)
        {
            // End Game
            isPlaying = false;
            EnabledSpawners();
            GameOver();
        }
    }

    private void EnabledSpawners()
    {
        foreach (GameObject spawner in Spawners)
        {
            spawner.SetActive(!spawner.activeSelf);

        }
    }

    private void ResetSettings()
    {
        Settings.PlayerLife = 3;
        Settings.isEvent = false;
        Settings.Score = 0;
        Settings.ScoreMultiplier = 1;
        Settings.TargetSpeed = 0.5f;
        Settings.SpawnFreqMax = 6f;
    }

    public void RestartGame()
    {
        Settings.newGame = false;
        ResetSettings();
        SceneManager.LoadScene("Alexis");
    }

    public void Menu()
    {
        Settings.newGame = true;
        ResetSettings();
        SceneManager.LoadScene("Alexis");
    }

    private void GameOver()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        ui.endGameUI.SetActive(true);
        ui.endGameUI.transform.DOScale(1f, 1.5f);

        ui.score.SetActive(false);
        ui.lives.SetActive(false);

    }

    public void UpdateScore()
    {
        ScoreValue.text = Settings.Score.ToString();
    }

    public void startEvent(TargetType type)
    {
        if(type == TargetType.normal || Settings.isEvent)
        {
            return;
        }

        switch (type)
        {
            case TargetType.loseLife:
                Settings.PlayerLife--;
                return;

            case TargetType.gainLife:
                Settings.PlayerLife++;
                return;

            case TargetType.multiplier:
                Settings.ScoreMultiplier = 2;
                break;

            case TargetType.speedPlus:
                Settings.TargetSpeed *= 2f;
                break;

            case TargetType.speedMinus:
                Settings.TargetSpeed /= 2f;
                break;

            case TargetType.slowmotion:
                Time.timeScale = 0f;
                break;

            default:
                break;
        }
        Settings.isEvent = true;
        this.type = type;
        Invoke(nameof(endEvent), 3f);
    }


    private void endEvent()
    {
        if (!Settings.isEvent)
            return;
        Settings.isEvent = false;
        switch (type)
        {
            case TargetType.multiplier:
                Settings.ScoreMultiplier = 1;
                break;

            case TargetType.speedPlus:
                Settings.TargetSpeed /= 2f;
                break;

            case TargetType.speedMinus:
                Settings.TargetSpeed *= 2f;
                break;

            case TargetType.slowmotion:
                Time.timeScale = 1f;
                break;

            default:
                break;
        }

    }

    //public void UpdateScoreMultiplier()
    //{
    //    ScoreMultValue.text = Settings.ScoreMultiplier.ToString();
    //}

    public void UpdateLife()
    {
        LivesValue.text = Settings.PlayerLife.ToString();
    }


    public float TargetSpeed
    {
        get { return Settings.TargetSpeed; }
        set { Settings.TargetSpeed = value; }
    }

    private void UpdateSpeed(float speed)
    {
        TargetSpeed = speed;
    }

}