using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ArcherBuild : MonoBehaviour
{
    public List<GameObject> archers = new List<GameObject>();
    public static ArcherBuild instance;

    public GameObject player;
    public GameObject archerPrefab;
    public GameObject target;

    Renderer targetRenderer;

    public Text archerStoneCountText;
    public Text archerCountText;
    public Image archerImage;   

    int archerStoneCount;
    int archerStoneNeedCount = 3;
    int archerCount = 0;

    float playerToArcherBuild;
    float posX = -1.5f;
    float posZ = 0;
    float distancePosZ;
    float stopPosZ = 0.1f;

    int step = 3;

    bool archerCompleted = false;
    private void Awake()
    {
        instance = this;
        targetRenderer=target.GetComponent<Renderer>();
    }
    private void Start()
    {
        archerStoneCountText.text = archerStoneCount + "" + " / " + archerStoneNeedCount;
    }
    private void Update()
    {
        playerToArcherBuild = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(playerToArcherBuild);
        if (archerStoneCount == archerStoneNeedCount)
        {
            archerCount++;
            archerCountText.text = "" + archerCount;
            archerStoneCount = 0;
            if (archerImage.fillAmount == 0)
            {
                archerImage.fillAmount = 1;
            }
        }
        if (archerCount > 0)
        {
            if (archerImage.fillAmount > 0f)
            {
                archerImage.fillAmount -= Time.deltaTime / 8f;
            }
            else
            {
                archerCount--;
                archerCountText.text = "" + archerCount;
                targetRenderer.enabled = true;
                archers.Add(Instantiate(archerPrefab, transform.position + Vector3.left * 2, Quaternion.identity));
                if (archers.Count > 1)
                {
                    posX += 1;
                }
                //Instantiate(archerPrefab, transform.position + Vector3.left * 2, Quaternion.identity);
                archerImage.fillAmount = 1;
            }
        }
        else
        {
            archerImage.fillAmount = 0;
        }
        for (int i = archers.Count - 1; i > archers.Count - 2; i--)
        {
            if (i > -1)
            {
                distancePosZ = archers[i].transform.position.z - target.transform.position.z;
                if (archers[i].GetComponent<NavMeshAgent>().isStopped == false)
                {
                    if (i <= step)
                    {
                        archers[i].GetComponent<NavMeshAgent>().destination = target.transform.position + new Vector3(posX, 0, posZ);
                    }
                    else
                    {
                        posZ--;
                        posX = -1.5f;
                        stopPosZ++;
                        step += 4;
                    }

                }
                if (Mathf.Abs(distancePosZ) < stopPosZ)
                {
                    archers[i].GetComponent<Animator>().SetFloat("Run", 1);
                    archers[i].GetComponent<NavMeshAgent>().isStopped = true;
                    //archers.RemoveAt(i);
                }
                //else
                //{
                //    //archers.Add(i);
                //    archers[i].GetComponent<Animator>().SetFloat("Run", 2);
                //    archers[i].GetComponent<NavMeshAgent>().isStopped = false;
                //}
            }

        }
        StartCoroutine(Lerp());
        //Debug.Log(distancePosZ);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!archerCompleted)
        {
            archerStoneCount++;
            archerStoneCountText.text = archerStoneCount + "" + " / " + archerStoneNeedCount;
            StackControl.instance.stackObjects.Remove(other.gameObject);
            Destroy(other.gameObject, 1);
            Transform playerStackClone = NewStack.instance.playerStack.transform;
            playerStackClone.position = new Vector3(playerStackClone.position.x, playerStackClone.position.y - 0.15f, playerStackClone.position.z);
        }
    }
    IEnumerator Lerp()
    {
        yield return new WaitForSeconds(1);
        if (StackControl.instance.stackObjects.Count > 0 && !archerCompleted)
        {
            Transform stackTransform = StackControl.instance.stackObjects[StackControl.instance.stackObjects.Count - 1].transform;
            if (playerToArcherBuild < 2.5f)
            {
                stackTransform.transform.parent = null;
                stackTransform.position = Vector3.Lerp(stackTransform.transform.position, transform.position, Time.deltaTime * 5);
            }
            if (stackTransform.transform.parent == null)
            {
                stackTransform.position = Vector3.Lerp(stackTransform.transform.position, transform.position, Time.deltaTime * 5);
            }
        }
    }
}
