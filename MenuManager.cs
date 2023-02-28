using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // CanvasUPにアタッチ

    GameObject menuWindow;
    GameObject menuTitle;

    GameObject charaText;
    GameObject itemText;
    GameObject systemText;
    GameObject albumText;

    GameObject menuEffect;

    GameObject charaMenu;
    GameObject itemMenu;
    GameObject systemMenu;
    GameObject albumMenu;

    Transform charatr;
    Transform itemtr;
    Transform systr;
    Transform albumtr;
    Transform effetr;

    ItemMenu itemMenuController;

    bool isEPressed = false;
    bool isZPressed = false;
    bool isUpPressed = false;
    bool isDownPressed = false;

    public bool isMenuOpen = false;
    bool isSubMenuOpen = false;

    float distanceChoice = 0.0f;

    bool charaNow = false;
    bool itemNow = false;
    bool sysNow = false;
    bool albumNow = false;

    

    // Start is called before the first frame update
    void Start()
    {
        

        menuWindow = transform.Find("MenuPanel/MenuWindow").gameObject;
        menuTitle = transform.Find("MenuPanel/MenuTitle").gameObject;

        charaText = transform.Find("MenuPanel/MenuWindow/CharaText").gameObject;
        itemText = transform.Find("MenuPanel/MenuWindow/ItemText").gameObject;
        systemText = transform.Find("MenuPanel/MenuWindow/SystemText").gameObject;
        albumText = transform.Find("MenuPanel/MenuWindow/AlbumText").gameObject;
        menuEffect = transform.Find("MenuPanel/MenuWindow/MenuEffect").gameObject;

        charaMenu = transform.Find("CharaMenu").gameObject;
        itemMenu = transform.Find("ItemMenu").gameObject;
        systemMenu = transform.Find("SystemMenu").gameObject;
        albumMenu = transform.Find("AlbumMenu").gameObject;

        charaMenu.SetActive(false);
        itemMenu.SetActive(false);
        systemMenu.SetActive(false);
        albumMenu.SetActive(false);

        itemMenuController = itemMenu.GetComponent<ItemMenu>();

        charatr = charaText.GetComponent<Transform>();
        itemtr = itemText.GetComponent<Transform>();
        systr = systemText.GetComponent<Transform>();
        albumtr = albumText.GetComponent<Transform>();

        distanceChoice = charatr.position.y - itemtr.position.y;

        HideMenu();

}

    // Update is called once per frame
    void Update()
    {
        isEPressed = Input.GetKeyDown(KeyCode.E);
        isZPressed = Input.GetKeyDown(KeyCode.Z);
        isUpPressed = Input.GetKeyDown(KeyCode.UpArrow);
        isDownPressed = Input.GetKeyDown(KeyCode.DownArrow);

        effetr = menuEffect.GetComponent<Transform>();

        

        // Eキーを押した場合の挙動
        EPressedReaction();

        // メニューでの選択
        ChoiceMenuType();

        // メニューでどれを選択しているかの確認
        WhereIsEffect();

        // Zキーを押されたとき選択されているメニューを開く
        OpenSubMenu();

    }

    void HideMenu()
    {
        menuWindow.SetActive(false);
        menuTitle.SetActive(false);

        charaText.SetActive(false);
        itemText.SetActive(false);
        systemText.SetActive(false);
        albumText.SetActive(false);
        menuEffect.SetActive(false);

    }

    void OpenMenu()
    {
        menuWindow.SetActive(true);
        menuTitle.SetActive(true);

        charaText.SetActive(true);
        itemText.SetActive(true);
        systemText.SetActive(true);
        albumText.SetActive(true);
        menuEffect.SetActive(true);
    }

    void WhereIsEffect()
    {
        if (effetr.position == charatr.position)
        {
            charaNow = true;
            itemNow = false;
            sysNow = false;
            albumNow = false;
        }
        else if (effetr.position == itemtr.position)
        {
            itemNow = true;
            charaNow = false;
            sysNow = false;
            albumNow = false;
        }
        else if (effetr.position == systr.position)
        {
            sysNow = true;
            charaNow = false;
            itemNow = false;
            albumNow = false;
        }
        else
        {
            albumNow = true;
            charaNow = false;
            itemNow = false;
            sysNow = false;
        }
    }

    void OpenSubMenu()
    {
        if (isZPressed && !isSubMenuOpen && isMenuOpen)
        {
            if (charaNow)
            {
                charaMenu.SetActive(true);
                itemMenu.SetActive(false);
                systemMenu.SetActive(false);
                albumMenu.SetActive(false);
                isSubMenuOpen = true;
            }
            else if (itemNow)
            {
                charaMenu.SetActive(false);
                itemMenu.SetActive(true);
                systemMenu.SetActive(false);
                albumMenu.SetActive(false);
            }
            else if (sysNow)
            {
                charaMenu.SetActive(false);
                itemMenu.SetActive(false);
                systemMenu.SetActive(true);
                albumMenu.SetActive(false);
            }
            else if (albumNow)
            {
                charaMenu.SetActive(false);
                itemMenu.SetActive(false);
                systemMenu.SetActive(false);
                albumMenu.SetActive(true);
            }
            isSubMenuOpen = true;
        }
        
    }

    void HideSubMenu()
    {
        charaMenu.SetActive(false);
        itemMenu.SetActive(false);
        systemMenu.SetActive(false);
        albumMenu.SetActive(false);
    }

    void EPressedReaction()
    {
        if (isEPressed && !isMenuOpen)
        {
            OpenMenu();
            isMenuOpen = true;
        }
        else if (isEPressed && isMenuOpen && !isSubMenuOpen)
        {
            HideMenu();
            isMenuOpen = false;
            effetr.position = charatr.position;
        }
        else if (isEPressed && isSubMenuOpen)
        {
            HideSubMenu();
            isSubMenuOpen = false;
        }
    }

    void ChoiceMenuType()
    {
        if (isMenuOpen && !isSubMenuOpen)
        {
            if (isDownPressed)
            {
                if (effetr.position == albumtr.position)
                {
                    return;
                }
                else
                {
                    effetr.position = new Vector3(effetr.position.x, effetr.position.y - distanceChoice, effetr.position.z);
                }
            }

            if (isUpPressed)
            {
                if (effetr.position == charatr.position)
                {
                    return;
                }
                else
                {
                    effetr.position = new Vector3(effetr.position.x, effetr.position.y + distanceChoice, effetr.position.z);
                }
            }

        }
    }
}
