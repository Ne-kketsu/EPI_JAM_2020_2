using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeBoard : MonoBehaviour
{
    public GameObject cell;
    public Vector3 [] size;
    public Transform position;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < size.Length; i += 1) {
            GameObject _cell = Instantiate(cell);
            Shapes2D.Shape shape = _cell.GetComponent<Shapes2D.Shape>();

            _cell.transform.SetParent(position, false);
            _cell.transform.localPosition += Vector3.right * (i);
            _cell.transform.localScale = size[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
