using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCollision : MonoBehaviour
{
    float stoneToStack;
    void Start()
    {
        
    }
    void Update()
    {
        if (StackControl.instance.stackObjects.Count > 0)
        {
            stoneToStack = Vector3.Distance(StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform.position, transform.position);
            //Debug.Log(stoneToStack);
            if (stoneToStack < 0.001f)
            {
                StackControl.instance.isStack = true;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.15f, gameObject.transform.position.z);
            }
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    StackControl.instance.isStack = true;
    //    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.15f, gameObject.transform.position.z);
    //}
}
