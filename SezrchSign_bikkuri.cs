using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SezrchSign_bikkuri : MonoBehaviour
{
    public float searchDistance = 1.0f;
    public float pivotCustom = 0.0f;
    public GameObject signObj;
    public bool isPlayerNear;

    GameObject canvasUp;

    // Start is called before the first frame update
    void Start()
    {
        signObj.SetActive(false);
        isPlayerNear = false;
        
        canvasUp = GameObject.Find("CanvasUp");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 plPos = player.transform.position;
        Vector3 obPos = gameObject.transform.position;
        Vector3 obPosCustom = new Vector3(obPos.x, obPos.y - pivotCustom, obPos.z);

        float dis = Vector3.Distance(plPos, obPosCustom);


        signObj.GetComponent<Transform>().position = new Vector3(plPos.x, plPos.y + 1.0f, plPos.z);
        if (dis <= searchDistance)
        {
            signObj.SetActive(true);
            
            isPlayerNear = true;
        }
        else
        {
            signObj.SetActive(false);
            
            isPlayerNear = false;
        }
    }

    bool FlagCheck(int i)
    {
        if (canvasUp.GetComponent<ItemFrame>().itemGet[i])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

