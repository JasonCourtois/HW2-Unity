using UnityEngine;

public class BallStopper : MonoBehaviour
{
    private MeshRenderer _mr;
    private MeshCollider _mc;

    private void Awake()
    {
        _mr = GetComponent<MeshRenderer>();
        _mc = GetComponent<MeshCollider>();
    }

    // Once ball passes through trigger, enable the mesh renderer for visuals and turn the mesh collider from a trigger into a regular collider.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Ball") return;

        _mr.enabled = true;
        _mc.isTrigger = false;
    }
}
