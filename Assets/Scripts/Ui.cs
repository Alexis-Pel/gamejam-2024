using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameManager gameManager;

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
        Camera.main.DOOrthoSize(1f, 3f).onComplete = () => { gameManager.enabled = true; };
    }
}
