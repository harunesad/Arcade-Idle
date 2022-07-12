using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStone : MonoBehaviour
{
    public GameObject player;
    public GameObject stonePrefab;
    public GameObject stoneBuild;
    public GameObject stackPoint;

    float startTime = 1;
    float repeatTime = 5;

    float distance;
    void Start()
    {
        InvokeRepeating("Spawn", startTime, repeatTime);
    }
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, stoneBuild.transform.position);
        int count = StackControl.instance.stackObjects.Count;
        //Debug.Log(distance);
    }
    void Spawn()
    {
        if (distance < 2)
        {
            var spawn = Instantiate(stonePrefab, stoneBuild.transform.position, stonePrefab.transform.rotation);
            spawn.transform.parent = stackPoint.transform;
            spawn.transform.rotation = stackPoint.transform.rotation;
            StackControl.instance.stackObjects.Add(spawn);
            StackControl.instance.isStack = false;
        }
        //else
        //{
        //int count = StackControl.instance.stackObjects.Count;
        //if (count > 1)
        //{
        //    for (int i = count - 1; i > count - 2; i--)
        //    {
        //        Transform endObject = StackControl.instance.stackObjects[count - 1].transform;
        //        Transform lastObject = StackControl.instance.stackObjects[count - 2].transform;
        //        endObject.position = new Vector3(lastObject.position.x, endObject.position.y, lastObject.position.z);
        //        endObject.position = new Vector3(endObject.position.x, endObject.position.y, endObject.position.z);
        //    }
        //}
        //}
    }
}
