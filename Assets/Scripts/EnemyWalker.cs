using UnityEngine;

public class Walker : Enemy
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float rotationSpeed = 360f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 targetPosition;
    private void Start()
    {
        startPosition = startPoint.position;
        endPosition = endPoint.position;
        targetPosition = endPoint.position;
    }
    private void Update()
    {
        if (!isAlive) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        UpdateDirection();
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            TurnArround();
        }
    }
    private void UpdateDirection()
    {
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0f;
        if (direction.magnitude <= 0.001f) return;
        Quaternion targetrotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetrotation, rotationSpeed * Time.deltaTime);
    }
    private void TurnArround()
    {
        targetPosition = targetPosition == endPosition? startPosition : endPosition;
    }
}
