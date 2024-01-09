using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private TMP_Text Score;

    [SerializeField]
    private TMP_Text Highscore;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        gameManager.RestartGame();
    }

    public void Menu()
    {
        gameManager.Menu();
    }
}
