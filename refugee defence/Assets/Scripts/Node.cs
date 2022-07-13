using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color haveColor;


    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }




    //OnMouseDown, OnMouseEnter, OnMouseExit fonksiyonlarý: Bunlarý bende daha önce kullanmadým, ama kýsaca mantýðý þu mouse'un olduðu nokta Enter'dan kontrol ediliyor,
    //OnMouseDown fonksiyonu ise týkladýðýmda olmasýný istediðim þeyi yazýyorum. OnMouse Exit ise mouse çýktýktan sonra ne olmasý gerektiðini yazýyorum.
    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build there ! - TODO: Display on screen.");
            return;
        }


        //BURDA HATA VERDÝ.


        GameObject turrentToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turrentToBuild, transform.position, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = haveColor;

    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
} 
