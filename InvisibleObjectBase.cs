using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleObjectBase : MonoBehaviour
{
    public bool isPlayerNear = false;

    public GameObject canvasUp;

    public GameObject signObjPrefab;
    public GameObject bikkuriObj;

    public float searchDistance = 1.0f;
    public float pivotCustom = 0.0f;

    public int itemNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFunc()
    {
        canvasUp = GameObject.Find("CanvasUp");
    }

    public virtual bool FlagCheck()
    {
        return true;
    }

    public void UpdateFunc()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 plPos = player.transform.position;
        Vector3 obPos = gameObject.transform.position;
        Vector3 obPosCustom = new Vector3(obPos.x, obPos.y - pivotCustom, obPos.z);

        float dis = Vector3.Distance(plPos, obPosCustom);

        Vector3 pos = new Vector3(plPos.x, plPos.y + 1.0f, plPos.z);
        if (dis <= searchDistance && FlagCheck())
        {
            bikkuriObj.SetActive(true);
            bikkuriObj.transform.position = pos;
            isPlayerNear = true;
        }
        else
        {
            bikkuriObj.SetActive(false);
            isPlayerNear = false;
        }
    }
}
