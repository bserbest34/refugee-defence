using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attiributes")]

    public float range = 15f;
    public float fireRate = 1;
    private float fireCountdown = 0f;



    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform rotateToChasis;

    public GameObject bulletPrefab;
    public Transform firePoint;


    private void Start()
    {
        //Burda alltaki UpdateTarget fonksiyonunu çalýþtýrýyorum 0.5 saniye aralýklarla.
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    //Bu fonksiyonun amacý silahýn odaklanacaðý target'ý deðiþtiriyor. Her bir target benim range'imden çýktýktan sonra baþka bir targeta odaklanýyor. Burasý biraz karýþýk.
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    private void Update()
    {

        //Bu if'in amacý target(düþman) yoksa silahý durduruyor.
        if (target == null)
            return;



        //Burda target'ýn pozisyonunu alýyorum ve silah ona sadece kitleniyor.

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotateToChasis.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;
        rotateToChasis.rotation = Quaternion.Euler(0f, rotation.y, 0f);



        //Silah'ýn ateþ etme sýklýðýný ayarlýyorum. Ýlk ateþ ettiðinden sonra geçen süreyi belirleyen satýr ise 81. satýr.
        if(fireCountdown  <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;


    }

    void Shoot()
    {
        //Bu fonksiyonun içinde önce bullet game object'i yaratýyorum, bu bullet'ý Instantiate fonksiyonuyla kopyalýyorum. Bir target alýyor ve mermiyi oraya atýyor.

        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }



    private void OnDrawGizmosSelected()
    {

        //Bu fonksiyon silahýn(turret'ýn) range'ini ayarlýyor.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
