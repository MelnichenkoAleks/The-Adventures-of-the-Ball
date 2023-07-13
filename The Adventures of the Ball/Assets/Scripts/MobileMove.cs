using UnityEngine.EventSystems;
using UnityEngine;

public class MobileMove : MonoBehaviour
{
    public bool isMovingRight, isMovingLeft; // Флаги для определения направления движения
    public int characterSpeed; 
    public Rigidbody2D rb; 
    public int jumpForce; 
    public bool isJumpAllowed; // Флаг для разрешения прыжка

    public AudioSource AudioSource;
    public AudioClip jumpSound;

    private void FixedUpdate()
    {
        if (isMovingRight)
        {
            float horizontalUpdate = +0.2f * Time.deltaTime;
            Move(horizontalUpdate); 
        }
        if (isMovingLeft)
        {
            float horizontalUpdate = -0.2f * Time.deltaTime;
            Move(horizontalUpdate); 
        }
    }

    public void Move(float horizontal)
    {
        Vector3 newVelocity = new Vector3(horizontal * characterSpeed, rb.velocity.y, 0);
        rb.velocity = newVelocity; 
    }

    public void StartMovingRight(BaseEventData data)
    {
        isMovingRight = true; 
    }

    public void StopMovingRight(BaseEventData data)
    {
        isMovingRight = false; 
        Move(0); 
    }

    public void StartMovingLeft(BaseEventData data)
    {
        isMovingLeft = true; 
    }

    public void StopMovingLeft(BaseEventData data)
    {
        isMovingLeft = false; 
        Move(0); 
    }

    public void JumpButton()
    {
        if (!isJumpAllowed)
        {
            rb.AddForce(new Vector2(0, jumpForce)); 
            AudioSource.PlayOneShot(jumpSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isJumpAllowed = false; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isJumpAllowed = true; 
        }
    }
}
