using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attak2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float Range = 10f;
    public float fireRate = 0.5f;
    public float bulletSpeed = 10f;

    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            ShootAtTarget();
            yield return new WaitForSeconds(fireRate);
        }
    }

    void ShootAtTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, Range);
        foreach (Collider target in targets)
        {
            if (target.CompareTag("gun"))
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                bullet.GetComponent<BulletEnemy>().SetDirection((target.transform.position - firePoint.position).normalized);
                return; // Solo dispara a un objetivo por ciclo
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
