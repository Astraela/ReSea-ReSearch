using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPlayerController : MonoBehaviour
{
    public KeyCode up = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode down = KeyCode.S;
    public KeyCode right = KeyCode.D;

    public float speed = 5;

    private KeyCode currentHorDirection = KeyCode.None;
    private KeyCode currentVerDirection = KeyCode.None;
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
            currentHorDirection = left;
        }else if(Input.GetKeyUp(left) && currentHorDirection == left){
            currentHorDirection = Input.GetKey(right) ? right : KeyCode.None;
        }
        if(Input.GetKeyDown(right)){
            currentHorDirection = right;
        }else if(Input.GetKeyUp(right) && currentHorDirection == right){
            currentHorDirection = Input.GetKey(left) ? left : KeyCode.None;
        }

        
        if(Input.GetKeyDown(up)){
            currentVerDirection = up;
        }else if(Input.GetKeyUp(up) && currentVerDirection == up){
            currentVerDirection = Input.GetKey(down) ? down : KeyCode.None;
        }
        if(Input.GetKeyDown(down)){
            currentVerDirection = down;
        }else if(Input.GetKeyUp(down) && currentVerDirection == down){
            currentVerDirection = Input.GetKey(up) ? up : KeyCode.None;
        }

        Vector2 hor = Vector2.right;
        Vector2 ver = Vector2.down;

        Vector2 input = hor * (currentHorDirection == left ? -1 : (currentHorDirection == right ? 1 : 0)) * speed;
        if(input.x != 0)
            GetComponentInChildren<SpriteRenderer>().flipX = input.x > 0;
        input += ver * (currentVerDirection == up ? -1 : (currentVerDirection == down ? 1 : 0)) * speed;
        rb.velocity = input;
    }
}
