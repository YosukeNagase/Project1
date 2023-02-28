using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CelohaneChildText : ObjectTextBase
{
    bool isPlayerNear = false;
    bool doesSquareSet = false;
    bool isItemGet = false;

    // display text list
    string text1 = "「扉の絵がこの教室のドアを指すなら対角に位置するこの机に何かあるってことかしら？」";
    string text2 = "椅子がある方向に何か収納スペースらしきものがある。";
    string text_choiceup1 = "探る";
    string text_choiceup_answer1 = "「痛い！何か鋭いものがあるの？」";
    string text_choicedown1 = "探らない";
    string text_choicedown_answer1 = "「素手で行くのは危険かもしれないわね。」";
    string textup1_1 = "「痛覚ってほんとに厄介だわ・・・。こんなものなんの役に立つの？」";
    string textup1_2 = "「とりあえず何か棒みたいのが欲しいわね。」";

    // set square
    string text3 = "このでかい三角形で中を探ってみようか？";
    string text_choiceup2 = "探る";
    string text_choiceup_answer2 = "何かにごつんと当たった。";
    string text_choicedown2 = "やめとく";
    string text_choicedown_answer2 = "「変なのが出てきてもやだし、、」";
    string textup2_1 = "「なかなか重い...。\nでも手前に移動させられそう。」";
    string textup2_2 = "近くまで引き寄せて見ると、全体が鋭くなっているわけではなさそうだ。";
    string textup2_3 = "「これならもてそうね\nう...でもやっぱり結構見た目の割に重いわね。」";
    string textup2_4 = "セロハンテープを手に入れた。";

    // after getting celohane
    string text4 = "机の中にはもう何も入っていないようだ。";
    string text5 = "「このスペースって何のためにあるのかしら？手を入れるとひんやりして気持ちいいわね。」";

    // display name list
    string name1 = "さや";
    string name2 = "";
    string choiceup_answer_name1 = "さや";
    string choicedown_answer_name1 = "さや";
    string nameup1_1 = "さや";
    string nameup1_2 = "さや";

    // set square
    string name3 = "";
    string choiceup_answer_name2 = "";
    string choicedown_answer_name2 = "さや";
    string nameup2_1 = "さや";
    string nameup2_2 = "";
    string nameup2_3 = "さや";
    string nameup2_4 = "";

    // after getting celohane
    string name4 = "";
    string name5 = "さや";

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
        isPlayerNear = this.GetComponent<CelohaneSearch>().isPlayerNear;
        
        if (itemMenuController.setItemNumber == 2)
        {
            doesSquareSet = true;
        }
        else
        {
            doesSquareSet = false;
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
            if (text == "" && canChoiceDisplay == false && isItemGet)
            {
                charaname = name4;
                nextCharaname = name5;
                text = text4;
                nextText = text5;
            }
            else if (text == "" && canChoiceDisplay == false)
            {
                charaname = name1;
                nextCharaname = name2;
                text = text1;
                nextText = text2;
            }
            else if (text == text2 && !doesSquareSet)
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
            else if (text == text2 && doesSquareSet)
            {
                nextCharaname = name3;
                nextText = text3;
            }
            else if (text == text3)
            {
                choiceup = text_choiceup2;
                choicedown = text_choicedown2;
                choiceup_answer_name = choiceup_answer_name2;
                choicedown_answer_name = choicedown_answer_name2;
                choiceup_answer = text_choiceup_answer2;
                choicedown_answer = text_choicedown_answer2;

                isNextChoice = true;
            }
            else if (text == text_choiceup_answer2)
            {
                nextCharaname = nameup2_1;
                nextText = textup2_1;
            }
            else if (text == textup2_1)
            {
                nextCharaname = nameup2_2;
                nextText = textup2_2;
            }
            else if (text == textup2_2)
            {
                nextCharaname = nameup2_3;
                nextText = textup2_3;
            }
            else if (text == textup2_3)
            {
                nextCharaname = nameup2_4;
                nextText = textup2_4;
                canvasUp.GetComponent<ItemFrame>().itemGet[0] = true;
                isItemGet = true;
                
            }
            else if (text == textup2_4) // Color change
            {
                textColor = Color.yellow;
                TextSound(getSE, getVolume);
                itemIcon.SetActive(true);
                itemIconImage.GetComponent<Image>().sprite = canvasUp.GetComponent<ItemFrame>().itemSprite[0];
                itemIconImage.GetComponent<Image>().SetNativeSize();
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
