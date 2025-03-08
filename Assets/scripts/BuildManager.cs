using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one buildMnager in scene");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject AnotherTurretPrefab;
    public GameObject MiniGunPrefab;

    private GameObject turretToBuild;

    /*void Start()
    {
        turretToBuild = standardTurretPrefab;
    }*/
    
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
