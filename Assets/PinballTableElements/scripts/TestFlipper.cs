using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    public HingeJoint hinge;
    [SerializeField] private float flipVelocity = -1000f;
    [SerializeField] private float returnVelocity = 1000f;
    [SerializeField] private string InputActionName;

    private InputAction _flipperInput;

    private JointMotor _motor;

    void Start()
    {
        if (InputActionName == null)
        {
            Debug.LogError($"InputActionName on {gameObject.name} not defined, defaulting to Left");
            InputActionName = "Left";
        }
        _flipperInput = InputSystem.actions.FindAction(InputActionName);
        _motor = hinge.motor;
    }

    void Update()
    {
        if (_flipperInput.IsPressed()) // or left/right keys
        {
            _motor.targetVelocity = flipVelocity;
        }
        else
        {
            _motor.targetVelocity = returnVelocity;
        }

        hinge.motor = _motor;
    }
}