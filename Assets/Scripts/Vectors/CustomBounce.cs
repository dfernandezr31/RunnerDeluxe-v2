using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomBounce : MonoBehaviour
{
    public float bounceFactor = 0.5f;

    private Rigidbody _rb;
    private Vector3 _lastVelocity;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _lastVelocity = _rb.linearVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;

        Vector3 reflectedVelocity = Vector3.Reflect(_lastVelocity, normal);

        _rb.AddForce(reflectedVelocity * bounceFactor, ForceMode.VelocityChange);
    }
}
