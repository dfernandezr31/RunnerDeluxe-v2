using UnityEngine;

public class SmoothLookAtTurret : MonoBehaviour
{
    public Transform target;
    [Range(0.1f, 20f)]
    public float rotationSpeed = 5f;

    void Update()
    {
        if (target == null) return;

        Vector3 directionToTarget = target.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
