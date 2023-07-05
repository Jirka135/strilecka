using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    private int damage;

    public delegate void EnemyDestroyedDelegate();
    public static event EnemyDestroyedDelegate OnEnemyDestroyed;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, angle + 90f);
    }

    public void SetDamage(int value)
    {
        damage = value;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (gameObject != null)
            {
                PlayerController.kills++;
                Destroy(gameObject);
                OnEnemyDestroyed?.Invoke();
            }

            if (collision.gameObject != null)
                Destroy(collision.gameObject);
        }
    }
}
