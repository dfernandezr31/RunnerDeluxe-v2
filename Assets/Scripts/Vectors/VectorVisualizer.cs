using UnityEngine;

public class VectorVisualizer : MonoBehaviour
{
    public Transform target;

    private void OnDrawGizmos()
    {
        if (target == null) return;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(this.transform.position, this.transform.forward * 1f);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, this.transform.up * 2f);

        Vector3 directionToTarget = target.position - transform.position;
        Vector3 normalizedDirection = directionToTarget.normalized; // magnitud = 1

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + Vector3.up * 0.1f, normalizedDirection * 3f);
    }
}
