using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Spawners;
    public TMP_Text ScoreValue;
    public TMP_Text LivesValue;

    private bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        EnabledSpawners();
    }

    // Update is called once per frame
    void Update()
    {
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