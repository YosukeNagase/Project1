using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobeChildText : ObjectTextBase
{
    bool isPlayerNear = false;
    bool doesHaveCelohane = false;
    bool isItemGet = false;

    public AudioClip crashSE;
    public float crashVolume = 0.1f;

    public Sprite crashedSphereSpr;
    public Sprite SphereSpr;
    public Sprite crashedSignalSphereSpr;
    public Sprite signalSphereSpr;

    string signalName = "globe_1_signal (3)";
    // display text list
    string text1 = "�n���V���B���{�̕������Ԃ��h���Ă��邪����͂��Ƃ��Ƃ��낤���H";
    string text2 = "�u���������{���Ă��Ƃ�����H�v";
    string text3 = "�@���Ă݂܂����H";
    string text_choiceup1 = "�@��";
    string text_choiceup_answer1 = "�J���J���ƍ���������B�ǂ���璆�g�͋󓴂̂悤���B";
    string text_choicedown1 = "�@���Ȃ�";
    string text_choicedown_answer1 = "�u�󂵂����邢���ˁv";

    // crashing with celohane
    string text4 = "�u���̓݊�Ȃ炱������邱�Ƃ��ł��邩������Ȃ���ˁB�v";
    string text5 = "�Z���n���e�[�v�Œn���V���󂵂܂����H";
    string text_choiceup2 = "��";
    string text_choiceup_answer2 = "�K�V���[�[�[�[���I�I�I�I�I";
    string text_choicedown2 = "�󂳂Ȃ�";
    string text_choicedown_answer2 = "�u���΂Ɋ���͕̂|������...�B�v";
    string textup2_1 = "�u...���ꂽ��ˁB\n��H���ɉ������邩���B�v";
    string textup2_2 = "�j�Ђ�T��ƒ����献���łĂ����B";
    string textup2_3 = "�u�J�M�v����ɓ��ꂽ�B";
    string textup2_4 = "�u�����...��������B\n���̕����ŉ����J����ꂻ���Ȃ���...�v";
    string textup2_5 = "�u���I�������̃h�A�Ƃ��ǂ�������H�v";

    // after getting key
    string text6 = "�u�Ȃ񂩗��΂ɉ󂷂ƍ߈����������ˁB�v";
    string text7 = "�u�ł��Ȃ�ł���ȂƂ��Ɍ����B�����̂�����B\n�Ă��ǂ�����ē��ꂽ�́B�v";

    // display name list
    string name1 = "";
    string name2 = "����";
    string name3 = "";
    string choiceup_answer_name1 = "";
    string choicedown_answer_name1 = "����";

    // crashing with celohane
    string name4 = "����";
    string name5 = "";
    string choiceup_answer_name2 = "";
    string choicedown_answer_name2 = "����";
    string nameup2_1 = "����";
    string nameup2_2 = "";
    string nameup2_3 = "";
    string nameup2_4 = "����";
    string nameup2_5 = "����";

    // after getting key
    string name6 = "����";
    string name7 = "����";

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
        isPlayerNear = this.GetComponent<SearchSign2>().isPlayerNear;
        
        if (itemMenuController.setItemNumber == 0)
        {
            doesHaveCelohane = true;
        }
        else
        {
            doesHaveCelohane = false;
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
            if (text == "" && canChoiceDisplay == false && !isItemGet)
            {
                charaname = name1;
                nextCharaname = name2;
                text = text1;
                nextText = text2;
            }
            else if (text == text2 && !doesHaveCelohane)
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
            else if (text == text2 && doesHaveCelohane)
            {
                nextCharaname = name4;
                nextText = text4;
            }
            else if (text == text4)
            {
                nextCharaname = name5;
                nextText = text5;
            }
            else if (text == text5)
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
                TextSound(crashSE, crashVolume);
                GetComponent<SpriteRenderer>().sprite = crashedSphereSpr;
                GameObject.Find(signalName).GetComponent<SpriteRenderer>().sprite = crashedSignalSphereSpr;
                
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

                canvasUp.GetComponent<ItemFrame>().itemGet[3] = true;
                isItemGet = true;
            }
            else if (text == textup2_3)
            {
                nextCharaname = nameup2_4;
                nextText = textup2_4;
                textColor = Color.yellow;
                TextSound(getSE, getVolume);
                itemIcon.SetActive(true);
                itemIconImage.GetComponent<Image>().sprite = canvasUp.GetComponent<ItemFrame>().itemSprite[3];
                itemIconImage.GetComponent<Image>().SetNativeSize();
            }
            else if (text == textup2_4)
            {
                nextCharaname = nameup2_5;
                nextText = textup2_5;
                textColor = Color.white;
                itemIcon.SetActive(false);
            }
            else if (text == "" && canChoiceDisplay == false && isItemGet)
            {
                charaname = name6;
                nextCharaname = name7;
                text = text6;
                nextText = text7;
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
