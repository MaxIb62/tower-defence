using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    void Start()
    {
        ShootInEightDirections();
    }

    void ShootInEightDirections()
    {
        Vector3[] directions = {
            Vector3.forward, Vector3.back, Vector3.left, Vector3.right,
            (Vector3.forward + Vector3.right).normalized, (Vector3.forward + Vector3.left).normalized,
            (Vector3.back + Vector3.right).normalized, (Vector3.back + Vector3.left).normalized
        };

        foreach (Vector3 dir in directions)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<BulletEnemy>().SetDirection(dir);
        }
    }
}
