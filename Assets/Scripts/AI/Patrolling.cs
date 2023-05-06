using System.Collections;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float waitTime;
    private int currentPoint;

    private void Start()
    {
        StartCoroutine(Patrol());
    }
    
    private IEnumerator Patrol()
    {
        var trans = transform;
        var position = trans.position;
        var targetPos = patrolPoints[currentPoint].position;
        
        while (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos,
                moveSpeed * Time.deltaTime);
            
            var targetDirection = targetPos - position;
            var newDirection = Vector3.RotateTowards(trans.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
        StartCoroutine(Patrol());
    }
}
