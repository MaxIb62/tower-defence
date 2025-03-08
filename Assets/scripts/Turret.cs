using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range = 25f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float rotationSpeed = 5f;
    public float turnSpeed = 10f;

    public GameObject Bulletpref;
    public Transform firePoint;

    public float FireRate = 1f;
    private float fireCountDown = 0f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) // Eliminado el punto y coma aquí
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;

        // smooth rotation
        partToRotate.rotation = Quaternion.Lerp(partToRotate.rotation, Quaternion.Euler(0f, rotation.y, 0f), Time.deltaTime * rotationSpeed * turnSpeed);

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / FireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject BulletGo = (GameObject)Instantiate(Bulletpref, firePoint.position, firePoint.rotation);
        bullet Bullet = BulletGo.GetComponent<bullet>();

        if (Bullet != null)
            Bullet.seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
