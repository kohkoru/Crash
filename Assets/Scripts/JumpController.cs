using UnityEngine;
using UnityEngine.Events;              
public class JumpController : MonoBehaviour
{
    [SerializeField]
    private InputController InputController;
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private UnityEvent onJump;
    [SerializeField]
    private float JumpVelocity = 8f;
    [SerializeField]
    private float gravity = -15f;
    private float verticalVelocity;
    public float VerticalVelocity => verticalVelocity;
    private bool hasGravity = true;
    public bool HasGravity
    {
        set
        {
            hasGravity = value;
            if (!hasGravity)
            {
                verticalVelocity = 0f;
            }
        }
    }
    private void Update()
    {
        if (characterController.isGrounded)
        {
            if (verticalVelocity > 0)
            {
                verticalVelocity = -2f;
            }
            if (InputController.Jump)
            {
                Jump();
            }
        }
        else
        {
            if (hasGravity)
            {
                verticalVelocity += gravity * Time.deltaTime;
            }
        }
    }
    public void Jump()
    {
        onJump?.Invoke();
        verticalVelocity = JumpVelocity;
    }
}
