using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    public List<GameObject> multeciler = new List<GameObject>();

    private GameObject spawnPoint;

    // put the points from unity interface
    public Transform[] wayPointList;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;


    private float timer;
    // Use this for initialization
    void Start()
    {
        timer = 0f;
        spawnPoint = GameObject.Find("SpawnPoint").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            walk();
        }
        timer += Time.deltaTime;
        if(timer >= 2f)
        {
            MulteciYarat();
            timer = 0;
        }
    }

    void walk()
    {
        GameObject.FindGameObjectWithTag("Enemy").transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);


        GameObject.FindGameObjectWithTag("Enemy").transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);


        // rotate towards the target
        //transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        // move towards the target
        //transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (GameObject.FindGameObjectWithTag("Enemy").transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            targetWayPoint = wayPointList[currentWayPoint];
        }
    }


    void MulteciYarat()
    {
        Instantiate(multeciler[Random.Range(0, 2)], spawnPoint.transform.position, Quaternion.identity);
    }
}
