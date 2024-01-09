using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Spawners;
    public TMP_Text ScoreValue;
    public TMP_Text LivesValue;
    private TargetType type;

    // CODE URIEL
    //public TMP_Text ScoreMultValue;

    private bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
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

    private void GameOver()
    {
        print("GAME OVER SCORE: " + Settings.Score);
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