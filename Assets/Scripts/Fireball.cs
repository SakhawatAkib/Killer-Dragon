using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
    public Vector2 StartingVelocity;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = StartingVelocity;
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreScript.scoreValues += 5;

        if(ScoreScript.scoreValues == Shooter.instance.maxScore)
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameObject.Find("Canvas").transform.GetChild(6).gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        // if fireball hit the enemy, it will die
        var enemy = collision.collider.GetComponent<Enemy>();

        enemy?.Die(); // that means, it check to see if the (enemy) exists and only (Die()) is exists will call Die()

        Destroy(gameObject);
    }
}
