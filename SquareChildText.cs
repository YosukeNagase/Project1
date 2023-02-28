using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareChildText : ObjectTextBase
{
    bool isPlayerNear = false;
    GameObject signal;

    // display text list

    string text1 = "「これは何かしら？\n大きな三角形・・・？」";
    string text2 = "「三角定規」を手に入れた";


    string name1 = "さや";
    string name2 = "";

    // Start is called before the first frame update
    void Start()
    {
        ObjectTextBase objectTextBase = GameObject.Find("ObjectTextBase").GetComponent<ObjectTextBase>();
        textWindow = objectTextBase.textWindow;
        textText = objectTextBase.textText;
        choiceTextUp = objectTextBase.choiceTextUp;
        choiceTextDown = objectTextBase.choiceTextDown;
        textEnd = objectTextBase.textEnd;
        choiceEffect = objectTextBase.choiceEffect;
        choiceEffect.GetComponent<Transform>().position = choiceTextUp.GetComponent<Transform>().position;

        nameWindow = objectTextBase.nameWindow;
        nameText = objectTextBase.nameText;

        canvasUp = objectTextBase.canvasUp;
        itemIcon = objectTextBase.itemIcon;
        itemIconImage = objectTextBase.itemIconImage;

        menuManager = canvasUp.GetComponent<MenuManager>();

        signal = GameObject.Find("set_square_1_signal (1)");

        audioSource = objectTextBase.audioSource;
        textSE = objectTextBase.textSE;
        getSE = objectTextBase.getSE;
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerNear = this.GetComponent<SearchSign2>().isPlayerNear;

        if (isPlayerNear)
        {
            WherePlayerIs();

            TextUpdate();
        }
        else
        {
            TextReset();
            if (signal == null)
            {
                Destroy(gameObject);
            }
        }
    }

    private void WherePlayerIs()
    {
        if (isPlayerNear)
        {
            if (text == "" && canChoiceDisplay == false)
            {
                charaname = name1;
                nextCharaname = name2;
                text = text1;
                nextText = text2;

                canvasUp.GetComponent<ItemFrame>().itemGet[2] = true;
            }
            else if (text == text2) // Color change
            {
                textColor = Color.yellow;
                TextSound(getSE, getVolume);
                itemIcon.SetActive(true);
                itemIconImage.GetComponent<Image>().sprite = canvasUp.GetComponent<ItemFrame>().itemSprite[2];
                itemIconImage.GetComponent<Image>().SetNativeSize();
            }
            if (text == text2 && textCharNumber == text.Length)
            {

                Destroy(signal);
                this.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f, 1.0f, 0.0f);
            }

            isZPressed = false;
        }
        else
        {
            text = "";
            nextText = "";
            charaname = "";
            nextCharaname = "";
        }
    }
}
