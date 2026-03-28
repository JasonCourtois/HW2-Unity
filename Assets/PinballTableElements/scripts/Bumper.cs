using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float BumperForce = 1000;
    private BallController _ballController;

  private void Awake()
  {
    _ballController = GameObject.FindWithTag("Ball").GetComponent<BallController>();
  }

  private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ball") return;
        _ballController.ApplyBallCollisionForce(collision, BumperForce);
    }
}
