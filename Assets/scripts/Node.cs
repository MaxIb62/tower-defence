using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hovercolor;

    private Renderer rend;
    private Color startcolor;

    private GameObject turret;
    
    // Start is called before the first frame update
    void Start()
    {
        rend= GetComponent<Renderer>();
        startcolor = rend.material.color;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("no se puede poner - TODO: display on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }
    void OnMouseEnter()
    {
        rend.material.color = hovercolor;
    }

    void OnMouseExit()
    {
        rend.material.color = startcolor;
    }

    // Update is called once per frame
}
