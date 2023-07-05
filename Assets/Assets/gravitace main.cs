using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI fpsText;
    private Rigidbody2D rb;
    public static int kills;
    private float FPSt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdateFPS", 0f, 1f);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;
        rb.velocity = movement;
        UpdateScoreText();
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.zero;
        }
    }

    void UpdateFPS()
    {
        FPSt = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = FPSt + " FPS"; 
    }

    void UpdateScoreText()
    {
        int enemycounter = EnemySpawner.enemies - kills;
        scoreText.text = "Score: " + kills.ToString() + '\n' + "Enemy count:" + enemycounter;
    }
}