using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDead : MonoBehaviour
{
    public GameObject enemy;
    private float minimumFallSpeed = 1f;
    public Animator animator;

    public AudioSource AudioSource;
    public AudioClip deadCube;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            // Проверяем, что игрок падает вниз (по оси Y) со скоростью не меньше минимальной
            if (playerRigidbody.velocity.y <= -minimumFallSpeed)
            {
                StartCoroutine(DestroyEnemy());
            }
        }
    }

    private IEnumerator DestroyEnemy()
    {
        
        animator.SetBool("EnemyCube", true);

        AudioSource.PlayOneShot(deadCube);

        
        yield return new WaitForSeconds(0.1f);

        
        Destroy(enemy);
    }
}