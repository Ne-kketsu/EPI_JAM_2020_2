using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellActions : MonoBehaviour
{
    private Shapes2D.Shape shape;
    public Color cellColor;
    // private Color initCellColor;



    // Start is called before the first frame update
    void Awake()
    {
        shape = GetComponent<Shapes2D.Shape>();
        // shape.settings.fillColor = new Color(cellColor.r, cellColor.g, cellColor.b, 1);
        // initCellColor = cellColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            shape.settings.fillColor = new Color(cellColor.r, cellColor.g, cellColor.b, 1);


    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (Input.GetMouseButton (0) || Input.touchCount > 0) {
    //         shape.settings.fillColor = other.GetComponent<PlayerController>().getColor();
    //     }
    // }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetMouseButton (0) || Input.touchCount > 0) {
            shape.settings.fillColor = other.GetComponent<PlayerController>().getColor();
        }
    }
}
