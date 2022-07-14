using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color haveColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager bManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        bManager = BuildManager.instance;
    }

    //OnMouseDown, OnMouseEnter, OnMouseExit fonksiyonlarý: Bunlarý bende daha önce kullanmadým, ama kýsaca mantýðý þu mouse'un olduðu nokta Enter'dan kontrol ediliyor,
    //OnMouseDown fonksiyonu ise týkladýðýmda olmasýný istediðim þeyi yazýyorum. OnMouse Exit ise mouse çýktýktan sonra ne olmasý gerektiðini yazýyorum.
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (bManager.GetTurretToBuild() == null)
            return; 


        if(turret != null)
        {
            Debug.Log("Can't build there ! - TODO: Display on screen.");
            return;
        }


        //BURDA HATA VERDÝ.


        GameObject turrentToBuild = bManager.GetTurretToBuild();
        turret = Instantiate(turrentToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (bManager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = haveColor;

    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
} 
