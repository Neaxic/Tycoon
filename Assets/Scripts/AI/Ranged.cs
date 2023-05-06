using UnityEngine;

public class Ranged : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float minimumDistanceToTarget;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float shootDelay;
    private float nextShotTime;
    [SerializeField] private Transform gunBarrel;

    private void Update()
    {
        var position = transform.position;
        var targetPos = target.position;

        if (Vector3.Distance(position, target.position) < minimumDistanceToTarget)
        {
            transform.position = Vector3.MoveTowards(position, targetPos, -moveSpeed * Time.deltaTime);
            TurnTowards(-(targetPos - position));
        }
        else
        {
            TurnTowards(targetPos - position);
            if (Time.time < nextShotTime) return;
            Instantiate(projectile, gunBarrel.position, transform.rotation);
            nextShotTime = Time.time + shootDelay;
        }
    }

    private void TurnTowards(Vector3 direction)
    {
        var newDirection = Vector3.RotateTowards(transform.forward, direction, turnSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
