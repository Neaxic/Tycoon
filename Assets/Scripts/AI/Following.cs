using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Following : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float minimumDistanceToTarget;
    
    private void Update()
    {
        var trans = transform;
        var position = trans.position;
        var targetPos = target.position;
        if (Vector3.Distance(position, target.position) > minimumDistanceToTarget)
        {
            transform.position = Vector3.MoveTowards(position, targetPos, moveSpeed * Time.deltaTime);
            
            var targetDirection = targetPos - position;
            var newDirection = Vector3.RotateTowards(trans.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        } else
        {
            print("ATTACKING!");
        }
    }
}
