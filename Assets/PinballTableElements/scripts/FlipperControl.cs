using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    public HingeJoint hinge;
    [SerializeField] private float flipVelocity = -1000f;
    [SerializeField] private float ReturnVelocity = 1000f;
    [SerializeField] private string InputActionName;
    [SerializeField] private float FlipperForce = 3000f;

    private BallController _ballController;
    private InputAction _flipperInput;

    private JointMotor _motor;

    private void Awake()
    {
        if (InputActionName == null)
        {
            Debug.LogError($"InputActionName on {gameObject.name} not defined, defaulting to Left");
            InputActionName = "Left";
        }
        _ballController = GameObject.FindWithTag("Ball").GetComponent<BallController>();

        _flipperInput = InputSystem.actions.FindAction(InputActionName);
        _motor = hinge.motor;
    }

    private void Update()
    {
        if (_flipperInput.IsPressed()) // or left/right keys
        {
            _motor.targetVelocity = flipVelocity;
        }
        else
        {
            _motor.targetVelocity = ReturnVelocity;
        }

        hinge.motor = _motor;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!_flipperInput.IsPressed() || collision.gameObject.tag != "Ball") return;
        _ballController.ApplyBallCollisionForce(collision, FlipperForce);
    }
}