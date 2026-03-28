using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private Rigidbody _rb;
    private InputAction _start;
    [SerializeField] private float StartForce = 9000;
    [SerializeField] private float TableAngle = -13;
    [SerializeField] private float TableGravity = 100;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _start = InputSystem.actions.FindAction("Start");

    }

    private void Update()
    {
        if (_start.IsPressed())
        {
            _start.Disable();
            _rb.AddForce(Vector3.left * StartForce);
        }

        if (transform.position.y < -6)
        {
            TriggerGameOver();
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.down * 30.19f);
        float angleInRadians = TableAngle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0);
        _rb.AddForce(direction * TableGravity);
    }

    public void ApplyBallCollisionForce(Collision collision, float bumperForce)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 direction = (transform.position - contact.point).normalized;    // Find the direction away from bumper using the balls position and the contact point of collision

        _rb.AddForce(direction * bumperForce);
    }

    public void ApplyBallDirectionForce(Vector3 direction, float force)
    {
        _rb.AddForce(direction * force);
    }

    private void TriggerGameOver()
    {
        SceneManager.LoadScene("gameOver");
    }
}
