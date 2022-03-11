using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public Transform subject;
    public Vector2 deadzone;
    public float speed;
    public float drag;

    private Camera cam;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 goal = subject.position;
        Vector2 velocity = Vector2.zero;

        Vector2 delta = transform.position - goal;

        if(Mathf.Abs(delta.x) > deadzone.x)
            velocity += Vector2.right * (delta.x < 0 ? 1 : -1) * speed;
        if(Mathf.Abs(delta.y) > deadzone.y)
            velocity += Vector2.up * (delta.y < 0 ? 1 : -1) * speed;

        rb.velocity = Vector2.Lerp(rb.velocity,velocity,drag/100);
    }
}
