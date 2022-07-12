using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackControl : MonoBehaviour
{
    public static StackControl instance;

    public List<GameObject> stackObjects;
    public GameObject stoneBuild;

    public Transform stackTransform;
    Transform transform;

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
            transform = stackObjects[stackObjects.Count - 1].transform;
            transform.position = Vector3.Lerp(transform.position, stackTransform.transform.position, Time.deltaTime * 1);
        }
        //gameObject.transform.rotation = Quaternion.identity;
    }
}
