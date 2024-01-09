using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameObject gameUI;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameObject WallShield;

    private void Awake()
    {
        if (!Settings.newGame)
        {
            Camera.main.orthographicSize = 1f;
            menuUI.SetActive(false);
            StartGame();
        }
    }

    public void OnPlayClick()
    {
        menuUI.SetActive(false);
        Camera.main.DOOrthoSize(1f, 2f).onComplete = () => { StartGame(); };
    }

    public void GoToMenu()
    {
        gameManager.enabled = false;
        WallShield.SetActive(true);
        Camera.main.DOOrthoSize(2f, 2f).onComplete = () => { gameUI.SetActive(false);  };
    }

    private void StartGame()
    {

        gameManager.enabled = true;
        gameUI.SetActive(true);
        WallShield.SetActive(false);
    }
}
