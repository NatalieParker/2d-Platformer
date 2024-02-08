using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float moveX = 0f;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MoveState{ idle, running, jumping, falling }


    void Start(){
        Debug.Log("Hello World");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update(){
        moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX*moveSpeed,rb.velocity.y);

        if (Input.GetButtonDown("Jump")){
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }

        UpdateAnim();
    }

    private void UpdateAnim(){
        MoveState state;
        if (moveX > 0f){
            state = MoveState.running;
            sprite.flipX = false;
        } else if (moveX < 0){
            state = MoveState.running;
            sprite.flipX = true;
        } else {
            state = MoveState.idle;
        }
        if (rb.velocity.y > 0.01f){
            state = MoveState.jumping;
        } else if (rb.velocity.y < -0.01f){
            state = MoveState.falling;
        }
        anim.SetInteger("State", (int)state);
    }

}
