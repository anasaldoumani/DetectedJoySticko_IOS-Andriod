using UnityEngine;

public class ThirdPersonCameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float distance = 5.0f; // Distance behind the target
    public float height = 2.0f; // Height above the target
    public float damping = 5.0f; // Damping effect for smooth following

    private Vector3 offset;

    void Start()
    {
        // Calculate the initial offset
        offset = new Vector3(0, height, -distance);
    }

    void LateUpdate()
    {
        // Calculate the desired position based on the target's position, offset, and the rotation
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);

        // Make the camera look at the target
        transform.LookAt(target.position);
    }
}
