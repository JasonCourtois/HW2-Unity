using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    private Rigidbody _rb;
    private InputAction _reset;
    private InputAction _start;
    [SerializeField] private float StartForce = 9000;
    [SerializeField] private float TableAngle = -13;
    [SerializeField] private float TableGravity = 100;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _reset = InputSystem.actions.FindAction("Reset");
        _start = InputSystem.actions.FindAction("Start");

    }

    private void Update()
    {
        if (_reset.IsPressed())
        {
            transform.position = new Vector3(9.55f, -1.93f, -9.36f);
            _start.Enable();
        }
        else if (_start.IsPressed())
        {
            _start.Disable();
            _rb.AddForce(Vector3.left * (StartForce + Random.Range(-500, 501)));
        }
    }

  private void FixedUpdate()
  {
    float angleInRadians = TableAngle * Mathf.Deg2Rad;
    Vector3 direction = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0);
    _rb.AddForce(direction * TableGravity);
  }

  public void ApplyBallForce(Collision collision, float BumperForce)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 direction = (transform.position - contact.point).normalized;    // Find the direction away from bumper using the balls position and the contact point of collision

        _rb.AddForce(direction * BumperForce);
    }
}
