using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Spawners;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject spawner in Spawners)
        {
            spawner.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Settings.PlayerLife <= 0)
        {
            // End Game
        }
    }


}