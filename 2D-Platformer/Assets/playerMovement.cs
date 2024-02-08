using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    void Start(){
        Debug.Log("Hello World");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX*7f,rb.velocity.y);

        if (Input.GetButtonDown("Jump")){
            rb.velocity = new Vector2(rb.velocity.x,7);
        }
    }

}
