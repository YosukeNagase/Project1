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
    string text1 = "地球儀だ。日本の部分が赤く塗られているがこれはもともとだろうか？";
    string text2 = "「ここが日本ってことかしら？」";
    string text3 = "叩いてみますか？";
    string text_choiceup1 = "叩く";
    string text_choiceup_answer1 = "カンカンと高い音が鳴る。どうやら中身は空洞のようだ。";
    string text_choicedown1 = "叩かない";
    string text_choicedown_answer1 = "「壊しちゃわるいしね」";

    // crashing with celohane
    string text4 = "「この鈍器ならこれを割ることができるかもしれないわね。」";
    string text5 = "セロハンテープで地球儀を壊しますか？";
    string text_choiceup2 = "壊す";
    string text_choiceup_answer2 = "ガシャーーーーン！！！！！";
    string text_choicedown2 = "壊さない";
    string text_choicedown_answer2 = "「流石に割るのは怖いかも...。」";
    string textup2_1 = "「...割れたわね。\nん？中に何かあるかも。」";
    string textup2_2 = "破片を探ると中から鍵がでてきた。";
    string textup2_3 = "「カギ」を手に入れた。";
    string textup2_4 = "「これは...鍵かしら。\nこの部屋で何か開けられそうなもの...」";
    string textup2_5 = "「あ！あそこのドアとかどうかしら？」";

    // after getting key
    string text6 = "「なんか流石に壊すと罪悪感があるわね。」";
    string text7 = "「でもなんでこんなとこに鍵を隠したのかしら。\nてかどうやって入れたの。」";

    // display name list
    string name1 = "";
    string name2 = "さや";
    string name3 = "";
    string choiceup_answer_name1 = "";
    string choicedown_answer_name1 = "さや";

    // crashing with celohane
    string name4 = "さや";
    string name5 = "";
    string choiceup_answer_name2 = "";
    string choicedown_answer_name2 = "さや";
    string nameup2_1 = "さや";
    string nameup2_2 = "";
    string nameup2_3 = "";
    string nameup2_4 = "さや";
    string nameup2_5 = "さや";

    // after getting key
    string name6 = "さや";
    string name7 = "さや";

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
