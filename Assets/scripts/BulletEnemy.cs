using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Vector3 moveDirection;
    public float speed = 10f;

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gun"))
        {
            Debug.Log("Impacto con: " + other.name); 
            Destroy(other.gameObject); // Destruye el objeto con tag "gun"
            Destroy(gameObject); 
        }
    }
}
