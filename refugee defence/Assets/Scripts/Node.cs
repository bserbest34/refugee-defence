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




    //OnMouseDown, OnMouseEnter, OnMouseExit fonksiyonlar�: Bunlar� bende daha �nce kullanmad�m, ama k�saca mant��� �u mouse'un oldu�u nokta Enter'dan kontrol ediliyor,
    //OnMouseDown fonksiyonu ise t�klad���mda olmas�n� istedi�im �eyi yaz�yorum. OnMouse Exit ise mouse ��kt�ktan sonra ne olmas� gerekti�ini yaz�yorum.
    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build there ! - TODO: Display on screen.");
            return;
        }


        //BURDA HATA VERD�.


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
