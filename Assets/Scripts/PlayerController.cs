using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private FixedJoystick _joystick;

    void Update()
    {
        // Get input from both the keyboard and the joystick
        float moveHorizontal = Input.GetAxis("Horizontal") + _joystick.Horizontal;
        float moveVertical = Input.GetAxis("Vertical") + _joystick.Vertical;

        // Normalize the movement vector to ensure consistent movement speed in all directions
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // Apply the movement to the player's position
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Optional: Make the player face the direction of movement
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, moveSpeed * Time.deltaTime);
        }
    }
}
