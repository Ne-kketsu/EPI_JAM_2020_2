using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Shapes2D.Shape shape;
    private float fillRotation = 0;
    private Rigidbody2D rb;
    private Vector3 inputPos;
    private Vector2 direction;
    public float moveSpeed = 100f;
    public float alpha = 0.5f;
    private AudioSource myAudio;
    private Color currentColor;
    private Color initColor;
    // Start is called before the first frame update
    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        shape = GetComponent<Shapes2D.Shape>();
        initColor = GetComponent<Shapes2D.Shape>().settings.fillColor;
        currentColor = initColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            inputPos = Camera.main.ScreenToWorldPoint(touch.position);
            inputPos.z = 0f;
            rb.position = inputPos;
        } else {
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (inputPos - transform.position).normalized;
            // inputPos.z = 0f;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
            // rb.position = inputPos;
            // transform.position = inputPos;
        }

        if (Input.GetMouseButton (0)) {
            // myAudio.Play();
            if (fillRotation >= 360)
                fillRotation = 0;
            else fillRotation += (7 + (Time.deltaTime));
        }
        if (Input.GetMouseButton (1))
            setColor(initColor);
        shape.settings.fillRotation = fillRotation;
    }

    public Color getColor()
    {
        return currentColor;
    }
    public void setColor(Color color)
    {
        color.a = alpha;
        currentColor = color;
        shape.settings.fillColor = color;
    }
    public void setEraser(Color color)
    {
        color.a = 0;
        currentColor = color;
        shape.settings.fillColor = color;
    }
}
