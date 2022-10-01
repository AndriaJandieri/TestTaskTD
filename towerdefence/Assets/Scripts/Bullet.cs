using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    private Transform target;
    public float bulletSpeed = 5f;
    
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceAtThatFrame = bulletSpeed * Time.deltaTime;

        if (direction.magnitude <= distanceAtThatFrame)
        {
            //HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceAtThatFrame, Space.World);
    }
    public void SeekToEnemy(Transform _target)
    {
        target = _target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) Destroy(gameObject);
    }
}
