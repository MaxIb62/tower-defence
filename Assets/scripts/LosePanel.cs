using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public GameObject panelLose; // LosePanel

    void Start()
    {
        panelLose.SetActive(false); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            panelLose.SetActive(true); 
            Time.timeScale = 0f; // StopGame
            Debug.Log("enemy enter tower");
        }
    }
}
