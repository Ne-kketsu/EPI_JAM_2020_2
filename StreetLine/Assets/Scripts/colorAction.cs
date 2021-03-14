using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorAction : MonoBehaviour
{
    private Shapes2D.Shape shape;
    private SpriteRenderer myRenderer;
    BoxCollider2D m_Collider;
    // private Color [] possibleColors = new Color[10];
    // Start is called before the first frame update
    void Awake()
    {
        shape = GetComponent<Shapes2D.Shape>();
        myRenderer = GetComponent<SpriteRenderer>();
        m_Collider = GetComponent<BoxCollider2D>();
        // shape.settings.fillColor = cellColor;
    }

    // void Update()
    // {
    //     Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //      Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

    //     Debug.Log(mousePosition);
    //     Debug.Log(pz);

    //     if (m_Collider.bounds.Contains(mousePosition))
    //     {
    //         Debug.Log("Bounds contain the point : " + mousePosition);
    //     }
    // }
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
