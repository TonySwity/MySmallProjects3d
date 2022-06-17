using UnityEngine;

public class SphereChaser : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _speed = 7f;


    private void Update()
    {
        Vector3 displacementFromTarget = _targetTransform.position - transform.position;
        Vector3 directionToTarget = displacementFromTarget.normalized;
        Vector3 velocity = directionToTarget * _speed;

        float distanceToTarget = displacementFromTarget.magnitude;

        if (distanceToTarget > 1.5f)
        {
            transform.Translate(velocity * Time.deltaTime);
        }
    }
}
