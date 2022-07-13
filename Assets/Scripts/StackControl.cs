using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackControl : MonoBehaviour
{
    public static StackControl instance;

    public List<GameObject> stackObjects;
    public GameObject stoneBuild;

    public Transform stackTransform;
    Transform transformObject;

    public bool isStack = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (!isStack)
        {
            if (stackObjects.Count > 0)
            {
                transformObject = stackObjects[stackObjects.Count - 1].transform;
                transformObject.position = Vector3.Lerp(transformObject.position, stackTransform.transform.position, Time.deltaTime * 5);
            }
        }
        //gameObject.transform.rotation = Quaternion.identity;
    }
}
