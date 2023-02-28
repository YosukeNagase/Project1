using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShinbunChildText : ObjectTextBase
{
    bool isPlayerNear = false;
    bool isItemGet = false;

    // display text list
    string text1 = "�V�����������Ă���";
    string text2 = "�u���̎���̂��̂�����E�E�E�H�v";
    string text3 = "�ǂ݂܂����H";
    string text_choiceup1 = "�ǂ�";
    string text_choiceup_answer1 = "�u2016�N�E�E�E�I�H�����Ԃ�̂̏ꏊ�̂悤�ˁB�v";
    string text_choicedown1 = "�����͂Ȃ�";
    string text_choicedown_answer1 = "�u���͂������ȁv";
    string textup1_1 = "�u�����͉������邽�߂̎{�݂Ȃ񂾂낤�H\n�l�������ς��W�܂ꂻ���B�v";
    string textup1_2 = "���͂���Ȃɑ傫���Ȃ��B�q���p�̎{�݂Ȃ̂��낤���H";
    //string textup1_2 = "���̎���ɐΑ������������u�����K�Ȃǂ͕��������Ƃ��Ȃ��B\n����������" +
    //    "�܂��Ȃ��̗ނ��ďd�v������Ă������H";
    string textup1_3 = "�u��A����́E�E�E�H\n�V�����̊ԂɃ����������B�v";
    string textup1_4 = "�����̉E���Ɂu���̊G�v��������Ă���B\n����ɂ́u���̊G�v������";
    string textup1_5 = "�u�V�����ɋ��܂�Ă��������v����ɓ��ꂽ�B";
    string textdown1_1 = "�u����Ȃ��Ƃ�肨���ǂ񂽂ׂ����v";
    string textdown1_2 = "�u���̉��I�H\n�������A�������͂����ɂ����̐�������E�E�E�B�v";

    // display name list
    string name1 = "";
    string name2 = "����";
    string name3 = "";
    string choiceup_answer_name1 = "����";
    string choicedown_answer_name1 = "����";
    string nameup1_1 = "����";
    string nameup1_2 = "";
    string nameup1_3 = "����";
    string nameup1_4 = "";
    string nameup1_5 = "����";
    string namedown1_1 = "�H�H�H";
    string namedown1_2 = "����";

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
