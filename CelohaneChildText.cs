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
    string text1 = "�u���̊G�����̋����̃h�A���w���Ȃ�Ίp�Ɉʒu���邱�̊��ɉ���������Ă��Ƃ�����H�v";
    string text2 = "�֎q����������ɉ������[�X�y�[�X�炵�����̂�����B";
    string text_choiceup1 = "�T��";
    string text_choiceup_answer1 = "�u�ɂ��I�����s�����̂�����́H�v";
    string text_choicedown1 = "�T��Ȃ�";
    string text_choicedown_answer1 = "�u�f��ōs���̂͊댯��������Ȃ���ˁB�v";
    string textup1_1 = "�u�Ɋo���Ăق�Ƃɖ���E�E�E�B����Ȃ��̂Ȃ�̖��ɗ��́H�v";
    string textup1_2 = "�u�Ƃ肠���������_�݂����̂��~������ˁB�v";

    // set square
    string text3 = "���̂ł����O�p�`�Œ���T���Ă݂悤���H";
    string text_choiceup2 = "�T��";
    string text_choiceup_answer2 = "�����ɂ���Ɠ��������B";
    string text_choicedown2 = "��߂Ƃ�";
    string text_choicedown_answer2 = "�u�ςȂ̂��o�Ă��Ă��₾���A�A�v";
    string textup2_1 = "�u�Ȃ��Ȃ��d��...�B\n�ł���O�Ɉړ�������ꂻ���B�v";
    string textup2_2 = "�߂��܂ň����񂹂Č���ƁA�S�̂��s���Ȃ��Ă���킯�ł͂Ȃ��������B";
    string textup2_3 = "�u����Ȃ���Ă�����\n��...�ł�����ς茋�\�����ڂ̊��ɏd����ˁB�v";
    string textup2_4 = "�Z���n���e�[�v����ɓ��ꂽ�B";

    // after getting celohane
    string text4 = "���̒��ɂ͂������������Ă��Ȃ��悤���B";
    string text5 = "�u���̃X�y�[�X���ĉ��̂��߂ɂ���̂�����H�������ƂЂ��肵�ċC����������ˁB�v";

    // display name list
    string name1 = "����";
    string name2 = "";
    string choiceup_answer_name1 = "����";
    string choicedown_answer_name1 = "����";
    string nameup1_1 = "����";
    string nameup1_2 = "����";

    // set square
    string name3 = "";
    string choiceup_answer_name2 = "";
    string choicedown_answer_name2 = "����";
    string nameup2_1 = "����";
    string nameup2_2 = "";
    string nameup2_3 = "����";
    string nameup2_4 = "";

    // after getting celohane
    string name4 = "";
    string name5 = "����";

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
