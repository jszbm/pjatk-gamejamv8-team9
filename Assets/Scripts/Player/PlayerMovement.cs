using Assets.Scripts.Controllers;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float x_speed = 10;
    [SerializeField] private float base_y_speed = 3;
    [SerializeField] private float additional_y_speed = 5;
    private InputAction speedUpAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speedUpAction = InputHandler.Instance.InputActions.Movement.SpeedUp;
    }
   
    private void FixedUpdate()
    {
        var moveDirection = InputHandler.Instance.InputActions.Movement.Direction.ReadValue<float>();

        float final_y_speed = base_y_speed;

        if (speedUpAction.IsPressed())
        {
            final_y_speed += additional_y_speed;
        }
        
        rb.linearVelocity = new Vector2(moveDirection * x_speed, -final_y_speed);
    }
}
