using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGun : MonoBehaviour
{
    BuildManager buildManager;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("standard Turret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another Turret Selected");
        buildManager.SetTurretToBuild(buildManager.AnotherTurretPrefab);
    }

    public void PurchaseMiniGum()
    {
        Debug.Log("MiniGun Turret Selected");
        buildManager.SetTurretToBuild(buildManager.MiniGunPrefab);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
