using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePlayerController : MonoBehaviour
{

    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public float Speed = 5;

    private KeyCode currentDirection = KeyCode.None;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(left)){
            currentDirection = left;
        }else if(Input.GetKeyUp(left) && currentDirection == left){
            currentDirection = Input.GetKey(right) ? right : KeyCode.None;
        }
        if(Input.GetKeyDown(right)){
            currentDirection = right;
        }else if(Input.GetKeyUp(right) && currentDirection == right){
            currentDirection = Input.GetKey(left) ? left : KeyCode.None;
        }

        rb.velocity = Vector2.left * (currentDirection == left ? 1 : (currentDirection == right ? -1 : 0)) * Speed;
    }
}
