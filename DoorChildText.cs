using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChildText : ObjectTextBase
{
    bool isPlayerNear = false;
    bool doesKeyHave = false;

    // display text list
    string text1 = "このドアには外側から鍵がかかっているようだ。";
    string text2 = "「わたしの力だと壊すのは難しそうね。」";
    string text3 = "鍵を探すしかなさそうだ。";

    // having a key
    string text4 = "「でもこの鍵を使えば開けられそうね。」";
    string text5 = "鍵を使って扉を開けますか？";
    string text_choiceup1 = "開ける";
    string text_choiceup_answer1 = "「外はどうなっているのかしら？」";
    string text_choicedown1 = "開けない";
    string text_choicedown_answer1 = "「外ちょっと怖いかも...。」";
    string textup1_1 = "ドアはスライド式でちょっと重い。";
    string textup1_2 = "ギギギ...と少しずつ開けると外の光が差し込んでくる。";
    string textup1_3 = "そして扉を最後まで開けると...";

    // display name list
    string name1 = "";
    string name2 = "さや";
    string name3 = "";

    // having a key
    string name4 = "さや";
    string name5 = "";
    string choiceup_answer_name1 = "さや";
    string choicedown_answer_name1 = "さや";
    string nameup1_1 = "";
    string nameup1_2 = "";
    string nameup1_3 = "";

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
        itemMenu = objectTextBase.itemMenu;
        itemIcon = objectTextBase.itemIcon;
        itemIconImage = objectTextBase.itemIconImage;

        menuManager = canvasUp.GetComponent<MenuManager>();
        itemMenuController = itemMenu.GetComponent<ItemMenu>();

        audioSource = objectTextBase.audioSource;
        textSE = objectTextBase.textSE;
        getSE = objectTextBase.getSE;
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerNear = this.GetComponent<DoorSearch>().isPlayerNear;

        if (itemMenuController.setItemNumber == 3)
        {
            doesKeyHave = true;
        }
        else
        {
            doesKeyHave = false;
        }

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
            else if (text == text2 && !doesKeyHave)
            {
                nextCharaname = name3;
                nextText = text3;
                //frag = false;
            }
            else if (text == text2 && doesKeyHave)
            {
                nextCharaname = name4;
                nextText = text4;
            }
            else if (text == text4)
            {
                nextCharaname = name5;
                nextText = text5;
                //frag = false;
            }
            else if (text == text5)
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
            else if (text == textup1_2)
            {
                nextCharaname = nameup1_3;
                nextText = textup1_3;
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
