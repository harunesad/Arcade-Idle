using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject parent;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Transform stacks = StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform;
    //    other.gameObject.transform.parent = parent.transform;
    //    other.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
    //    StackControl.instance.stackObjects.Remove(other.gameObject);
    //    NewStack.instance.posZ += 0.15f;
    //    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + NewStack.instance.posZ);
    //    //NewStack.instance.isMove = true;
    //}
}
