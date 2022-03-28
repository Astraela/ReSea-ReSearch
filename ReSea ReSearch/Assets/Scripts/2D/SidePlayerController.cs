using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePlayerController : MonoBehaviour
{

    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public float speed = 5;

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

        Vector2 angle = Vector2.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,.71f,7);
        if(hit){
            rb.gravityScale = 0;
            angle = new Vector2(hit.normal.y,-hit.normal.x);
        }else{
            rb.gravityScale = 20;
        }

        Vector2 input = angle * (currentDirection == left ? -1 : (currentDirection == right ? 1 : 0)) * speed;
        if(input.x != 0)
            GetComponentInChildren<SpriteRenderer>().flipX = input.x > 0;
        rb.velocity = input;
    }
}
