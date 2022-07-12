using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCollision : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        StackControl.instance.isStack = true;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.15f, gameObject.transform.position.z);
    }
}
