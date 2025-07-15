using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 movement;
    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 currentPosition = rigidBody.position;
        Vector3 MoveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPosition
        = currentPosition + MoveDirection * (moveSpeed * Time.fixedDeltaTime);

        rigidBody.MovePosition(newPosition);
    }
}
