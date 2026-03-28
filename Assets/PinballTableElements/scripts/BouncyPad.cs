using UnityEngine;

public class BouncyPad : MonoBehaviour
{
    private BallController _ballController;
    [SerializeField] private float BounceForce = 100;

    private void Awake()
    {
        _ballController = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ball") return;
        _ballController.ApplyBallDirectionForce(transform.right, BounceForce);
    }
}
