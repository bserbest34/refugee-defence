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
        //Burda alltaki UpdateTarget fonksiyonunu �al��t�r�yorum 0.5 saniye aral�klarla.
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }


    //Bu fonksiyonun amac� silah�n odaklanaca�� target'� de�i�tiriyor. Her bir target benim range'imden ��kt�ktan sonra ba�ka bir targeta odaklan�yor. Buras� biraz kar���k.
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

        //Bu if'in amac� target(d��man) yoksa silah� durduruyor.
        if (target == null)
            return;



        //Burda target'�n pozisyonunu al�yorum ve silah ona sadece kitleniyor.

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotateToChasis.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;
        rotateToChasis.rotation = Quaternion.Euler(0f, rotation.y, 0f);



        //Silah'�n ate� etme s�kl���n� ayarl�yorum. �lk ate� etti�inden sonra ge�en s�reyi belirleyen sat�r ise 81. sat�r.
        if(fireCountdown  <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;


    }

    void Shoot()
    {
        //Bu fonksiyonun i�inde �nce bullet game object'i yarat�yorum, bu bullet'� Instantiate fonksiyonuyla kopyal�yorum. Bir target al�yor ve mermiyi oraya at�yor.

        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }



    private void OnDrawGizmosSelected()
    {

        //Bu fonksiyon silah�n(turret'�n) range'ini ayarl�yor.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
