using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed;
    public float JumpSpeed;
    private float HorizontalInput;
    private bool Jumping;

    public AudioSource AudioSource;
    public AudioClip jumpSound;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(HorizontalInput * Speed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && !Jumping)
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * JumpSpeed);
        Jumping = true;
        AudioSource.PlayOneShot(jumpSound);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Ground")
        {
            Jumping = false;
        }
    }
}
