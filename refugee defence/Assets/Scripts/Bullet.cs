using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFame, Space.World);


    }

    //Target'a vurmasýný saðlayan fonksiyon. 
    void HitTarget()
    {
        //Önce mermiyi kopyalýyorum.
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }



}
