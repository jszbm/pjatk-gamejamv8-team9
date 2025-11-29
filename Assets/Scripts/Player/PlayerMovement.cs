using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float xInput;
    private float yInput;
    [SerializeField] private float x_speed = 10;
    [SerializeField] private float base_y_speed = 3;
    [SerializeField] private float additional_y_speed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
    }
    
    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        float raw_yInput = Input.GetAxis("Vertical");
        yInput = Mathf.Min(raw_yInput, 0f);
    }

    private void FixedUpdate()
    {
        float final_y_speed = base_y_speed;

        if (yInput < 0f)
        {
            final_y_speed += additional_y_speed;
        }
        
        rb.linearVelocity = new Vector2(xInput * x_speed, -final_y_speed);

    }
}
