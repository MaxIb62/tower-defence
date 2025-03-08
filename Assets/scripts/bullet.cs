using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;

    public float Speed = 70f; 
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

    }

    void HitTarget()
    {
        if (target != null)
        {
            Debug.Log("Destruyendo target: " + target.name);
            Destroy(target.gameObject);
            target = null; // Evita que otras balas intenten destruirlo
        }
        Destroy(gameObject);
    }
}
