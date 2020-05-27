using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBoard : MonoBehaviour
{
    public GameObject cell;
    public float size;
    public string [] colors;

    public float vSpace = 1;
    public float hSpace = 1;
    public Transform position;
    public GameObject [] patterns;
    private Color initOutlineBoardColor;
    private int currentPattern = 0;
    // private bool isGridShown = false;
    void Awake()
    {
        float hSize = Mathf.Sqrt(size);
        float vSize = Mathf.Sqrt(size);
        initOutlineBoardColor = position.parent.GetComponent<Shapes2D.Shape>().settings.outlineColor;
        
        for (int j = 0; j < vSize; j += 1) {
            for (int i = 0; i < hSize; i += 1) {
                GameObject _cell = Instantiate(cell);
                Shapes2D.Shape shape = _cell.GetComponent<Shapes2D.Shape>();

                _cell.transform.SetParent(position, false);
                _cell.transform.localPosition += Vector3.right * (i * hSpace);
                _cell.transform.localPosition += Vector3.down * (j * vSpace);
            }
        }
        // position.GetChild(0).GetComponent<Shapes2D.Shape>().settings.fillColor = Color.red; 
        // Debug.Log(position.childCount);
    }
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            if (patterns.Length > 0)
                compare(patterns[currentPattern]);
            else ScreenshotHandler.TakeScreenshot_Static(1920, 1080);
        }
        if (Input.GetKeyDown("e")) {
                showGrid();
        }
        OnPatternCheck();

    }

    void showGrid()
    {
        int maxValidCell = position.childCount;
        int i = 0;
    
        while (i < maxValidCell) {
            creatorAction gameBoardCellShape = position.GetChild(i).GetComponent<creatorAction>();

            gameBoardCellShape.hideCell();
            i += 1;
        }
    }
    void OnPatternCheck()
    {
        if (position.parent.GetComponent<Shapes2D.Shape>().settings.outlineColor == Color.green || 
        position.parent.GetComponent<Shapes2D.Shape>().settings.outlineColor == Color.red) {
            position.parent.GetComponent<Shapes2D.Shape>().settings.outlineSize -= (Time.deltaTime / 10);
            if (position.parent.GetComponent<Shapes2D.Shape>().settings.outlineSize <= 0f) {
                position.parent.GetComponent<Shapes2D.Shape>().settings.outlineSize = 0.1f;
                position.parent.GetComponent<Shapes2D.Shape>().settings.outlineColor = new Color (initOutlineBoardColor.r, initOutlineBoardColor.g, initOutlineBoardColor.b, 1);
            }
        }
    }
    void compare(GameObject pattern)
    {
        int maxValidCell = position.childCount;
        int validCell = 0;
        int i = 0;
        Shapes2D.Shape gameBoardShape = position.parent.GetComponent<Shapes2D.Shape>();

        while (i < maxValidCell) {
            Shapes2D.Shape gameBoardCellShape = position.GetChild(i).GetComponent<Shapes2D.Shape>();
            Shapes2D.Shape patternCellShape = pattern.transform.GetChild(i).GetComponent<Shapes2D.Shape>();
            if (gameBoardCellShape.settings.fillColor == patternCellShape.settings.fillColor)
                validCell += 1;
            i += 1;
        }
        int successRate = (validCell - maxValidCell) + maxValidCell;
        if (currentPattern < patterns.Length) {
            if (successRate >= (maxValidCell / 2)) {
                gameBoardShape.settings.outlineColor = Color.green;
                resetPattern(pattern);
                currentPattern += 1;
                resetPattern(patterns[currentPattern]);
            }
            else gameBoardShape.settings.outlineColor = Color.red;
        }
    }

    void resetPattern(GameObject pattern)
    {
        int i = 0;
        int patternCell = pattern.transform.childCount;
        while (i < patternCell) {
            SpriteRenderer cellRenderer = pattern.transform.GetChild(i).GetComponent<SpriteRenderer>();

            if (cellRenderer.enabled) cellRenderer.enabled = false; else cellRenderer.enabled = true;
            i += 1;
        }
    }
}
