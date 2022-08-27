using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 10f;

    private Transform targetPoint;
    private int waypointIndex = 0;

    void Start()
    {
        targetPoint = WayPoints.points[0];
        speed = GetComponent<Enemy>().enemyScriptableObject.emenyMovementSpeed;
    }

    void Update()
    {
        Vector3 direction = targetPoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetPoint.position) <= 0.2f)
        {
            UpdateWayPoint();
        }
    }

    void UpdateWayPoint()
    {
        if (waypointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        targetPoint = WayPoints.points[waypointIndex];
    }
}
