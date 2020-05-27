using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorBoard : MonoBehaviour
{
    public GameObject cell;
    public Color [] colors;
    public Transform position;

    public float Space = 1;

    // Start is called before the first frame update
    void Awake()
    {
        int hSize = (int)Mathf.Sqrt(colors.Length);
        float vSize = Mathf.Sqrt(colors.Length);
        int i = 0;
        int k = 0;
        
        // for (int j = 0; j < vSize; j += 1) {
        //     for (int i = 0; i < hSize; i += 1) {
        //         GameObject _cell = Instantiate(cell);
        //         Shapes2D.Shape shape = _cell.GetComponent<Shapes2D.Shape>();

        //         _cell.transform.SetParent(position, false);
        //         _cell.transform.localPosition += Vector3.right * (i * Space);
        //         _cell.transform.localPosition += Vector3.down * (j * Space);
        //         colors[i].a = 1;
        //         shape.settings.fillColor = new Color(colors[i].r, colors[i].g, colors[i].b, colors[i].a);
        //     }
        // }
        for (int j = 0; j < colors.Length; j += 1) {
            if ((j % hSize) == 0) {
                i += 1;
                if (i > 0)
                    k = 0;
            }
            Debug.Log(i);
            GameObject _cell = Instantiate(cell);
            Shapes2D.Shape shape = _cell.GetComponent<Shapes2D.Shape>();

            _cell.transform.SetParent(position, false);
            _cell.transform.localPosition += Vector3.right * (k * Space);
            _cell.transform.localPosition += Vector3.down * (i * Space);
            colors[j].a = 1;
            shape.settings.fillColor = new Color(colors[j].r, colors[j].g, colors[j].b, colors[j].a);
            k += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
