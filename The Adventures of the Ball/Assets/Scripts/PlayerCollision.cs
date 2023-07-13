using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip starSound;
    public AudioClip hitSound;
    public AudioClip gameoverSound;
    public AudioClip waterDeadSound;

    public GameObject finish;
    public AudioClip victory;

    public Animator animator;

    private bool isGameOver = false;
    private bool starCollected = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            AudioSource.PlayOneShot(hitSound);
            HealthManager.health--;

            if (HealthManager.health <= 0)
            {
                animator.SetBool("PlayerDead", true);
                AudioSource.PlayOneShot(gameoverSound);
                isGameOver = true;
                StartCoroutine(GameOverRoutine());
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }

    IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(1);
        if (isGameOver)
        {
            RestartScene();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator DelayedStarCollection(float delay)
    {
        starCollected = true;
        yield return new WaitForSeconds(delay);
        StarManager.starsis--;
        starCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Dead")
        {
            animator.SetBool("PlayerDead", true);
            AudioSource.PlayOneShot(gameoverSound);
            isGameOver = true;
            StartCoroutine(GameOverRoutine());
        }
        else if (CompareTag("Player") && collision.CompareTag("Finish"))
        {
            AudioSource.PlayOneShot(victory);
            StartCoroutine(TransitionToNextSceneWithDelay(1f));
        }
        if (collision.transform.tag == "Water")
        {
            animator.SetBool("WaterDead", true);
            AudioSource.PlayOneShot(waterDeadSound);
            isGameOver = true;
            StartCoroutine(GameOverRoutine());
        }
        else if (collision.transform.tag == "Star" && !starCollected)
        {
            Destroy(collision.gameObject);
            AudioSource.PlayOneShot(starSound);

            StartCoroutine(DelayedStarCollection(0.1f)); // Call DelayedStarCollection coroutine with a delay of 0.1 seconds
        }
        if (StarManager.starsis <= 0)
        {
            finish.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    IEnumerator TransitionToNextSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}