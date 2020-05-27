using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeCellAction : MonoBehaviour
{
    private Vector3 scale;
    // private Color [] possibleColors = new Color[10];
    // Start is called before the first frame update
    void Awake()
    {
        scale = GetComponent<Transform>().localScale;
        // shape.settings.fillColor = cellColor;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (Input.GetMouseButtonDown (0)) {
            other.GetComponent<Transform>().localScale = GetComponent<Transform>().localScale;
        // }
        // Debug.Log(GetComponent<Transform>().localScale);
    }
}
