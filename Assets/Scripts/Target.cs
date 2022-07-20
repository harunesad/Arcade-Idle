using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public static Target instance;
    public GameObject archerBuild;
    float oldPosX, oldPosY, oldPosZ;
    public bool playerClick = false;
    float newPosx, newPosy, newPosz;
    float posX, posY, posZ;
    bool archerMove = false;
    int index = 0;
    int archerIndex;
    float distanceArcherMove;
    float stopArcherMove = 0.1f;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Ground"))
                {
                    if (archerBuild.activeSelf && ArcherBuild.instance.archers.Count > 0)
                    {
                        newPosx = hit.point.x;
                        newPosy = hit.point.y;
                        newPosz = hit.point.z;
                        oldPosX = transform.position.x;
                        oldPosY = transform.position.y;
                        oldPosZ = transform.position.z;
                        posX = newPosx - oldPosX;
                        posY = newPosy - oldPosY;
                        posZ = newPosz - oldPosZ;
                        Debug.Log(hit.point);
                        transform.position = new Vector3(newPosx, newPosy, newPosz);
                        archerMove = true;
                        //ArcherBuild.instance.archers[index].GetComponent<NavMeshAgent>().isStopped = false;

                        //for (int i = 0; i < ArcherBuild.instance.archers.Count; i++)
                        //{
                        //    Transform archersPos = ArcherBuild.instance.archers[i].transform;
                        //    archersPos.position = new Vector3(archersPos.transform.position.x + posX, archersPos.transform.position.y, archersPos.transform.position.z + posZ);
                        //}
                        //archerBuild.activeSelf
                    }
                    playerClick = false; 
                }
                else if(hit.transform.CompareTag("Player"))
                {
                    playerClick = true;
                }
                else
                {
                    playerClick = false;
                }
            }
        }
        if (archerMove == true)
        {
            index = Mathf.Clamp(index, 0, ArcherBuild.instance.archers.Count - 1);
            ArcherBuild.instance.archers[index].GetComponent<NavMeshAgent>().isStopped = false;
            Transform archersPos = ArcherBuild.instance.archers[index].transform;
            //archersPos.position = Vector3.Lerp(archersPos.position, archersPos.position + new Vector3(posX, 0, posZ), Time.deltaTime * 5);
            ArcherBuild.instance.archers[index].GetComponent<Animator>().SetFloat("Run", 2);
            ArcherBuild.instance.archers[index].GetComponent<NavMeshAgent>().destination = archersPos.position + new Vector3(posX, 0, posZ);

            distanceArcherMove = ArcherBuild.instance.archers[index].transform.position.z - transform.position.z;
            if (Mathf.Abs(distanceArcherMove) < stopArcherMove)
            {
                ArcherBuild.instance.archers[index].GetComponent<NavMeshAgent>().isStopped = true;
                ArcherBuild.instance.archers[index].GetComponent<Animator>().SetFloat("Run", 1);
                index++;
            }
            Debug.Log(distanceArcherMove);
        }
    }
}
