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

    //OnMouseDown, OnMouseEnter, OnMouseExit fonksiyonlar�: Bunlar� bende daha �nce kullanmad�m, ama k�saca mant��� �u mouse'un oldu�u nokta Enter'dan kontrol ediliyor,
    //OnMouseDown fonksiyonu ise t�klad���mda olmas�n� istedi�im �eyi yaz�yorum. OnMouse Exit ise mouse ��kt�ktan sonra ne olmas� gerekti�ini yaz�yorum.
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


        //BURDA HATA VERD�.


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
