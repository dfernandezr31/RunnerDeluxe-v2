using UnityEngine;

public class GuardAI : MonoBehaviour
{
    public Transform playerTarget;
    public float fieldOfViewAngle = 90f;

    private Material _material;
    private Color _originalColor;

    void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        _originalColor = _material.color;
    }

    void Update()
    {
        if (playerTarget == null) return;

        Vector3 directionToPlayer = (playerTarget.position - transform.position).normalized;

        float dotProduct = Vector3.Dot(transform.forward, directionToPlayer);

        float fovDotProductThrehold = Mathf.Cos(fieldOfViewAngle * 0.5f * Mathf.Deg2Rad);

        if (dotProduct >= fovDotProductThrehold)
        {
            _material.color = Color.red;
        }
        else
        {
            _material.color = _originalColor;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-fieldOfViewAngle * 0.5f, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(fieldOfViewAngle * 0.5f, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;

        Gizmos.DrawRay(this.transform.position, leftRayDirection * 5f);
        Gizmos.DrawRay(this.transform.position, rightRayDirection * 5f);
    }
}
