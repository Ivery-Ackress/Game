using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformRotator : MonoBehaviour
{
    [SerializeField] private Rigidbody platform;
    [SerializeField] private float rotationSpeed = 10;

    private float targetRotationSpeed = 0f;

    public void RotateRight(InputAction.CallbackContext context)
    {
        targetRotationSpeed = context.performed ? rotationSpeed : 0f;
    }

    public void RotateLeft(InputAction.CallbackContext context)
    {
        targetRotationSpeed = context.performed ? -rotationSpeed : 0f;
    }

    private void FixedUpdate()
    {
        if (targetRotationSpeed != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0, targetRotationSpeed * Time.fixedDeltaTime, 0);
            platform.MoveRotation(platform.rotation * deltaRotation);
        }
    }
}
