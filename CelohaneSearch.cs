using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelohaneSearch : InvisibleObjectBase
{
    // Start is called before the first frame update
    void Start()
    {
        searchDistance = 1.0f;
        pivotCustom = 0.0f;

        itemNumber = 1;

        InvisibleObjectBase objectBase = GameObject.Find("InvisibleObjectBase").GetComponent<InvisibleObjectBase>();
        canvasUp = objectBase.canvasUp;
        signObjPrefab = objectBase.signObjPrefab;
        bikkuriObj = Instantiate(signObjPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        bikkuriObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFunc();
    }

    public override bool FlagCheck()
    {
        if (canvasUp.GetComponent<ItemFrame>().itemGet[1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
