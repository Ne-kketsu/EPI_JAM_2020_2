using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorAction : MonoBehaviour
{
    private Shapes2D.Shape shape;
    private SpriteRenderer myRenderer;
    // private Color [] possibleColors = new Color[10];
    // Start is called before the first frame update
    void Awake()
    {
        shape = GetComponent<Shapes2D.Shape>();
        myRenderer = GetComponent<SpriteRenderer>();
        // shape.settings.fillColor = cellColor;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        #if UNITY_ANDROID
            if (myRenderer.enabled)
                    other.GetComponent<PlayerController>().setColor(shape.settings.fillColor);
        #endif
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (myRenderer.enabled) {
            if (Input.GetMouseButtonDown (0)) {
                other.GetComponent<PlayerController>().setColor(shape.settings.fillColor);
            }
        }
    }
}
