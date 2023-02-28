using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShinbunChildText : ObjectTextBase
{
    bool isPlayerNear = false;
    bool isItemGet = false;

    // display text list
    string text1 = "新聞紙が落ちている";
    string text2 = "「この時代のものかしら・・・？」";
    string text3 = "読みますか？";
    string text_choiceup1 = "読む";
    string text_choiceup_answer1 = "「2016年・・・！？ずいぶん昔の場所のようね。」";
    string text_choicedown1 = "興味はない";
    string text_choicedown_answer1 = "「今はいいかな」";
    string textup1_1 = "「ここは何をするための施設なんだろう？\n人がいっぱい集まれそう。」";
    string textup1_2 = "机はそんなに大きくない。子供用の施設なのだろうか？";
    //string textup1_2 = "この時代に石像をあちこち置く慣習などは聞いたことがない。\nそういった" +
    //    "まじないの類って重要視されてたっけ？";
    string textup1_3 = "「ん、これは・・・？\n新聞紙の間にメモがあるわ。」";
    string textup1_4 = "メモの右下に「扉の絵」が書かれている。\n左上には「机の絵」がある";
    string textup1_5 = "「新聞紙に挟まれていたメモ」を手に入れた。";
    string textdown1_1 = "「そんなことよりおうどんたべたい」";
    string textdown1_2 = "「今の何！？\n幻聴か、もしくはここにいる霊の声かしら・・・。」";

    // display name list
    string name1 = "";
    string name2 = "さや";
    string name3 = "";
    string choiceup_answer_name1 = "さや";
    string choicedown_answer_name1 = "さや";
    string nameup1_1 = "さや";
    string nameup1_2 = "";
    string nameup1_3 = "さや";
    string nameup1_4 = "";
    string nameup1_5 = "さや";
    string namedown1_1 = "？？？";
    string namedown1_2 = "さや";

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
            }
            else if (text == text2)
            {
                nextCharaname = name3;
                nextText = text3;
            }
            else if (text == text3)
            {
                choiceup = text_choiceup1;
                choicedown = text_choicedown1;
                choiceup_answer_name = choiceup_answer_name1;
                choicedown_answer_name = choicedown_answer_name1;
                choiceup_answer = text_choiceup_answer1;
                choicedown_answer = text_choicedown_answer1;

                isNextChoice = true;
            }
            else if (text == text_choiceup_answer1)
            {
                nextCharaname = nameup1_1;
                nextText = textup1_1;
            }
            else if (text == textup1_1)
            {
                nextCharaname = nameup1_2;
                nextText = textup1_2;
            }
            else if (text == textup1_2 && !isItemGet)
            {
                nextCharaname = nameup1_3;
                nextText = textup1_3;
            }
            else if (text == textup1_3)
            {
                nextCharaname = nameup1_4;
                nextText = textup1_4;
            }
            else if (text == textup1_4)
            {
                nextCharaname = nameup1_5;
                nextText = textup1_5;
                canvasUp.GetComponent<ItemFrame>().itemGet[1] = true;
                
                isItemGet = true;
            }
            else if (text == textup1_5) // Color change
            {
                textColor = Color.yellow;
                TextSound(getSE, getVolume);
                itemIcon.SetActive(true);
                itemIconImage.GetComponent<Image>().sprite = canvasUp.GetComponent<ItemFrame>().itemSprite[1];
                itemIconImage.GetComponent<Image>().SetNativeSize();
            }
            else if (text == text_choicedown_answer1)
            {
                nextCharaname = namedown1_1;
                nextText = textdown1_1;
            }
            else if (text == textdown1_1)
            {
                nextCharaname = namedown1_2;
                nextText = textdown1_2;
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
