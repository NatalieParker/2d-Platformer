using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private float moveX = 0f;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MoveState{ idle, running, jumping, falling }
    [SerializeField] private AudioSource jumpSound;

    void Start(){
        Debug.Log("Hello World");
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update(){
        moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX*moveSpeed,rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded()){
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            jumpSound.Play();
        }

        updateAnim();
    }

    private void updateAnim(){
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
    
    private bool isGrounded(){
        
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);;
    }
}
