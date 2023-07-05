using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public TextMeshProUGUI textComponent;
    private Rigidbody2D rb;
    public static int kills;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
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

    void UpdateScoreText()
    {
        textComponent.text = "Score: " + kills.ToString();
    }
}