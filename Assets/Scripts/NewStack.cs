using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStack : MonoBehaviour
{
    public GameObject player;
    float distanceToStack;
    void Start()
    {
        
    }
    void Update()
    {
        distanceToStack = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(distanceToStack);
        if (distanceToStack < 2)
        {
            for (int i = StackControl.instance.stackObjects.Count - 1; i > -1; i--)
            {
                Transform stack = StackControl.instance.stackObjects[i].transform;
                stack.position = Vector3.Lerp(stack.position, transform.position, Time.deltaTime * 5);
            }
        }
    }
}
