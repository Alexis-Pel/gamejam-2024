using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [SerializeField]
    private Texture2D crosshair;


    private void Start()
    {
        // Offset To Change
        //Cursor.SetCursor(crosshair, new Vector2(0, 0), CursorMode.Auto);
    }


    // Update is called once per frame
    void Update()
    {
    }
}
