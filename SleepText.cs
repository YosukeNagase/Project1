using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepText : ObjectTextBase
{
    bool isTextFinish = false;
    bool isPlayerNear = true;
    public GameObject whiteOut;

    string text1 = "ここはどこだろう。";
    string text2 = "深い深い海のような";
    string text3 = "暗い暗い宇宙のような";
    string text4 = "不安だけど、\nどこか落ち着く。";
    string text5 = "きっとわたしの知らない場所だけど";
    string text6 = "いつかは知る景色なのだ。";
    string text7 = "なんだかそんな気がする。";
    string text8 = "だから怖くない。";
    string text9 = "...。";
    string text10 = "何かが近づいてくる。";
    string text11 = "まぶた越しでもわかる大きい何か。";
    string text12 = "「夢...」";
    string text13 = "想いと記憶の交差点";
    string text14 = "白い光がわたしを包んだ。";


    string name1 = "";
    string name2 = "";
    string name3 = "";
    string name4 = "";
    string name5 = "";
    string name6 = "";
    string name7 = "";
    string name8 = "";
    string name9 = "";
    string name10 = "";
    string name11 = "";
    string name12 = "？？？";
    string name13 = "";
    string name14 = "";

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

        whiteOut.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WherePlayerIs();
        TextUpdate();

        if (isTextFinish && textWindow.activeSelf == false)
        {
            whiteOut.SetActive(true);
            Invoke("SceneChange", 2.0f);
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
                nextCharaname = name6;
                nextText = text6;
            }
            else if (text == text6)
            {
                nextCharaname = name7;
                nextText = text7;
            }
            else if (text == text7)
            {
                nextCharaname = name8;
                nextText = text8;
            }
            else if (text == text8)
            {
                nextCharaname = name9;
                nextText = text9;
            }
            else if (text == text9)
            {
                nextCharaname = name10;
                nextText = text10;
            }
            else if (text == text10)
            {
                nextCharaname = name11;
                nextText = text11;
            }
            else if (text == text11)
            {
                nextCharaname = name12;
                nextText = text12;
            }
            else if (text == text12)
            {
                nextCharaname = name13;
                nextText = text13;
            }
            else if (text == text13)
            {
                nextCharaname = name14;
                nextText = text14;
            }
            else if (text == text14 && textCharNumber == text.Length)
            {
                isTextFinish = true;
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

    void SceneChange()
    {
        SceneManager.LoadScene("Classroom_1");
    }
}
