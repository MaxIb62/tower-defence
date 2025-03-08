using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;

    public float Speed = 70f;
    public float explosionRadio=0f;
    public void seek (Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFRame = Speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFRame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFRame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        if (target != null)
        {
            Debug.Log("Destruyendo target: " + target.name);
            if(explosionRadio > 0f)
            {
                Explode();
            }
            else
            {
                Damage(target);
            }
            Destroy(target.gameObject);
            target = null; 
        }
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadio);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage (Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadio);
    }
}
