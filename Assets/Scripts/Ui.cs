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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayClick()
    {
        menuUI.SetActive(false);
        Camera.main.DOOrthoSize(1f, 2f).onComplete = () => { gameManager.enabled = true; gameUI.SetActive(true); Destroy(WallShield); };
    }
}
