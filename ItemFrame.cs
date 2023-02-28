using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFrame : MonoBehaviour
{
    GameObject itemFrame1;
    GameObject itemFrame2;
    GameObject itemFrame3;
    GameObject itemFrame4;
    GameObject itemFrame5;
    GameObject itemFrame6;
    GameObject itemFrame7;
    GameObject itemFrame8;
    GameObject itemFrame9;
    GameObject itemFrame10;
    GameObject itemFrame11;
    GameObject itemFrame12;
    GameObject itemFrame13;
    GameObject itemFrame14;
    GameObject itemFrame15;

    public Sprite[] itemSprite = new Sprite[15];

    //public bool item1Get = false;
    //public bool item2Get = false;
    //public bool item3Get = false;
    //public bool item4Get = false;
    //public bool item5Get = false;
    //public bool item6Get = false;
    //public bool item7Get = false;
    //public bool item8Get = false;
    //public bool item9Get = false;
    //public bool item10Get = false;
    //public bool item11Get = false;
    //public bool item12Get = false;
    //public bool item13Get = false;
    //public bool item14Get = false;
    //public bool item15Get = false;

    public bool[] itemGet = new bool[15];

    // Start is called before the first frame update
    void Start()
    {
        itemFrame1 = transform.Find("ItemMenu/ItemFrame1").gameObject;
        itemFrame2 = transform.Find("ItemMenu/ItemFrame2").gameObject;
        itemFrame3 = transform.Find("ItemMenu/ItemFrame3").gameObject;
        itemFrame4 = transform.Find("ItemMenu/ItemFrame4").gameObject;
        itemFrame5 = transform.Find("ItemMenu/ItemFrame5").gameObject;
        itemFrame6 = transform.Find("ItemMenu/ItemFrame6").gameObject;
        itemFrame7 = transform.Find("ItemMenu/ItemFrame7").gameObject;
        itemFrame8 = transform.Find("ItemMenu/ItemFrame8").gameObject;
        itemFrame9 = transform.Find("ItemMenu/ItemFrame9").gameObject;
        itemFrame10 = transform.Find("ItemMenu/ItemFrame10").gameObject;
        itemFrame11 = transform.Find("ItemMenu/ItemFrame11").gameObject;
        itemFrame12 = transform.Find("ItemMenu/ItemFrame12").gameObject;
        itemFrame13 = transform.Find("ItemMenu/ItemFrame13").gameObject;
        itemFrame14 = transform.Find("ItemMenu/ItemFrame14").gameObject;
        itemFrame15 = transform.Find("ItemMenu/ItemFrame15").gameObject;

        for (int i = 0; i < 15; i++)
        {
            int j = i + 1;
            itemSprite[i] = transform.Find("ItemMenu/ItemFrame" + j + "/Item").gameObject.GetComponent<Image>().sprite;
        }

        for (int i = 0; i < itemGet.Length; i++)
        {
            itemGet[i] = false;
            ItemHide(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < itemGet.Length; i++)
        {
            ItemGet(itemGet[i], i);
        }
        
    }

    void ItemHide(int i)
    {
        int j = i + 1;
        GameObject itemImage = transform.Find("ItemMenu/ItemFrame" + j + "/Item").gameObject;
        GameObject noitemImage = transform.Find("ItemMenu/ItemFrame" + j + "/NoItem").gameObject;
        
        noitemImage.SetActive(true);
        itemImage.SetActive(false);
        if (j == 8 || j == 15)
        {
            GameObject itemImage2 = transform.Find("ItemMenu/ItemFrame" + j + "/Item2").gameObject;
            itemImage2.SetActive(false);
        }
    }

    void ItemGet(bool itemGet, int i)
    {
        int j = i + 1;
        if (itemGet)
        {
            GameObject itemImage = transform.Find("ItemMenu/ItemFrame" + j + "/Item").gameObject;
            GameObject noitemImage = transform.Find("ItemMenu/ItemFrame" + j + "/NoItem").gameObject;

            noitemImage.SetActive(false);
            itemImage.SetActive(true);
        }
    }
}
