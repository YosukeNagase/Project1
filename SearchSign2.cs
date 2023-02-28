using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchSign2 : MonoBehaviour
{
    public float searchDistance = 5.0f;
    public float pivotCustom = 0.4f;
    public GameObject signObj;
    public bool isPlayerNear;

    // Start is called before the first frame update
    void Start()
    {
        if (signObj != null)
        {
            signObj.SetActive(false);
        }
        isPlayerNear = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 plPos = player.transform.position;
        Vector3 obPos = gameObject.transform.position;
        Vector3 obPosCustom = new Vector3(obPos.x, obPos.y - pivotCustom, obPos.z);

        float dis = Vector3.Distance(plPos, obPosCustom);


        if (dis <= searchDistance)
        {
            if (signObj != null)
            {
                signObj.SetActive(true);
            }
            isPlayerNear = true;
        }
        else
        {
            if (signObj != null)
            {
                signObj.SetActive(false);
            }
            isPlayerNear = false;
        }
    }

    
}
