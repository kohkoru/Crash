using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField]
    private InputController InputController;
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private float JumpVelocity = 8f;
    [SerializeField]
    private float gravity = -15f;
    private float verticalVelocity;
    public float VerticalVelocity => verticalVelocity;

    private void Update()
    {
        if (characterController.isGrounded)
        {
            verticalVelocity = -2f;
        }
        if (InputController.Jump)
        {
            verticalVelocity = JumpVelocity;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
    }
}
