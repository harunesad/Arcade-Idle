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
        Debug.Log(distance);
    }
    void Spawn()
    {
        if (distance < 2)
        {
            var spawn = Instantiate(stonePrefab, stonePrefab.transform.position, stonePrefab.transform.rotation);
            spawn.transform.parent = stackPoint.transform;
            spawn.transform.rotation = stackPoint.transform.rotation;
            StackControl.instance.stackObjects.Add(spawn);
            StackControl.instance.isStack = false;
        }
        //else if (StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform.position != )
        //{
                
        //}
    }
}
