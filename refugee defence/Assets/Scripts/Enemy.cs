using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Düþmanýn içinde olan script dosyasý.



    public float speed = 10;
    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = WayPoints.points[0];
    }
    private void Update()
    {
        //Burda gideceði target'ý veriyorum.
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        //Burda da hangi target'a gideceðini kontrol ediyorum.
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

    }


    //Burda ise bir sonra ki target'ý set ediyorum.
    void GetNextWayPoint()
    {
        if(wavePointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }
}
