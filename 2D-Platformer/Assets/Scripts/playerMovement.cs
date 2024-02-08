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
        if (moveX > 0f){
            anim.SetBool("Running", true);
            sprite.flipX = false;
        } else if (moveX < 0){
            anim.SetBool("Running", true);
            sprite.flipX = true;
        } else {
            anim.SetBool("Running", false);
        }
    }

}
