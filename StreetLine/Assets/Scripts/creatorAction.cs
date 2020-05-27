using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatorAction : MonoBehaviour
{
    private Shapes2D.Shape shape;
    private Color initCellColor;
    private bool cellHiden = false;
    // private Color initCellColor;



    // Start is called before the first frame update
    void Awake()
    {
        shape = GetComponent<Shapes2D.Shape>();
        initCellColor = shape.settings.fillColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            if (cellHiden)
                shape.settings.fillColor = new Color(initCellColor.r, initCellColor.g, initCellColor.b, 0);
            else shape.settings.fillColor = new Color(initCellColor.r, initCellColor.g, initCellColor.b, 0.5F);
        // if (Input.GetKeyDown("e")) {
        //     if (hideGUI) hideGUI = false;
        //     else hideGUI = true;
        //     if (shape.settings.fillColor.r == initCellColor.r && shape.settings.fillColor.g == initCellColor.g && shape.settings.fillColor.b == initCellColor.b && hideGUI) {
        //             shape.settings.fillColor = new Color(initCellColor.r, initCellColor.g, initCellColor.b, 0.5F);
        //     }
        //     if (shape.settings.fillColor.r == initCellColor.r && shape.settings.fillColor.g == initCellColor.g && shape.settings.fillColor.b == initCellColor.b && !hideGUI) {
        //             shape.settings.fillColor = new Color(initCellColor.r, initCellColor.g, initCellColor.b, 0);
        //     }
        // }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Color otherColor;
        if (other.GetComponent<PlayerController>()) {
            
            shape.settings.outlineSize = 0.001F;
        }
        #if UNITY_ANDROID
            otherColor = other.GetComponent<PlayerController>().getColor();

            if ((otherColor.r == initCellColor.r && otherColor.g == initCellColor.g && otherColor.b == initCellColor.b) && cellHiden)
                shape.settings.fillColor = new Color(initCellColor.r, initCellColor.g, initCellColor.b, 0);
            else shape.settings.fillColor = otherColor;
        #endif
        if (Input.GetMouseButton (0)) {
            otherColor = other.GetComponent<PlayerController>().getColor();

            if ((otherColor.r == initCellColor.r && otherColor.g == initCellColor.g && otherColor.b == initCellColor.b) && cellHiden)
                shape.settings.fillColor = new Color(initCellColor.r, initCellColor.g, initCellColor.b, 0);
            else shape.settings.fillColor = otherColor;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // shape.settings.outlineSize = 0.0001F;
        if (Input.GetMouseButton (0)) {
            Color otherColor = other.GetComponent<PlayerController>().getColor();

            if ((otherColor.r == initCellColor.r && otherColor.g == initCellColor.g && otherColor.b == initCellColor.b) && cellHiden)
                shape.settings.fillColor = new Color(initCellColor.r, initCellColor.g, initCellColor.b, 0);
            else shape.settings.fillColor = otherColor;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
            shape.settings.outlineSize = 0F;
    }
    public void hideCell()
    {
            if (cellHiden) cellHiden = false;
            else cellHiden = true;
            if (shape.settings.fillColor.r == initCellColor.r && shape.settings.fillColor.g == initCellColor.g && shape.settings.fillColor.b == initCellColor.b && !cellHiden) {
                    shape.settings.fillColor = new Color(initCellColor.r, initCellColor.g, initCellColor.b, 0.5F);
            }
            if (shape.settings.fillColor.r == initCellColor.r && shape.settings.fillColor.g == initCellColor.g && shape.settings.fillColor.b == initCellColor.b && cellHiden) {
                    shape.settings.fillColor = new Color(initCellColor.r, initCellColor.g, initCellColor.b, 0);
            }
    }
}
