using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    public GameObject itemMenu;

    GameObject canvasUp;
    GameObject canvasUnder;

    GameObject itemFrameEffect;
    GameObject itemFrame1; // フレームの基準点
    GameObject itemFrame2; // 横移動の距離把握
    GameObject itemFrame6; // 縦移動の距離把握
    GameObject itemWindowImage2;
    GameObject itemNameText;
    GameObject itemExplainText;


    Transform frameeffetr;
    Transform frame1tr;
    Transform frame2tr;
    Transform frame6tr;

    float distanceVertical = 0;
    float distanceHorizontal = 0;

    float verticalLimitUp = 0;
    float verticalLimitDown = 0;
    float horizontalLimitLeft = 0;
    float horizontalLimitRight = 0;

    float bitError = 0.1f;

    bool isZPressed = false;
    bool isUpPressed = false;
    bool isDownPressed = false;
    bool isRightPressed = false;
    bool isLeftPressed = false;

    int x = 0;
    int y = 0;


    string[] itemName = new string[15];
    string[] itemExplain = new string[15];

    public int setItemNumber = -1;



    // Start is called before the first frame update
    void Start()
    {
        itemName[0] = "セロハン";
        itemName[1] = "メモ";
        itemName[2] = "三角定規";
        itemName[3] = "カギ";
        itemName[4] = "植木鉢";
        itemName[5] = "般若のお面";
        itemName[6] = "CDケース";
        itemName[7] = "バケツ";
        itemName[8] = "ライター";
        itemName[9] = "100万円";
        itemName[10] = "赤い本";
        itemName[11] = "ハンドガン";
        itemName[12] = "灰皿";
        itemName[13] = "青い本";
        itemName[14] = "ティーカップ";

        itemExplain[0] = "なにやら重量があって鋭いところがある。\n叩きつければ脆いものなら壊せそうだが・・・。";
        itemExplain[1] = "新聞紙に挟まっていたメモ。右下には扉、左上には机が書いてある。\n何かが隠してあることを表しているのだろうか。";
        itemExplain[2] = "大きい三角形の物体だ。なにやら数字がいっぱい書いてあり用途は思いつかない。";
        itemExplain[3] = "どこかのカギっぽい。多分ドアの鍵だと思われる。\nでも" +
            "なんでったってわたしをこんなとこに閉じ込めたのだろう。";
        itemExplain[4] = "植物が植えてある。こんな小さいのに入れて何の意味があるのだろうか？いわゆる観賞用というやつだろうか。";
        itemExplain[5] = "なんかめっちゃ怖い。人の顔ってこんなだったっけ？サイズ的には私の顔よりちょっと大きいくらいか・・・。";
        itemExplain[6] = "透明なケースと虹色に光る薄い円盤だ。なんらかの電子機器に関するものだろうが一体これで何ができるんだろう。";
        itemExplain[7] = "銀色の底が深めの器だ。あんまり綺麗じゃないみたいで、内側には汚れがある。あんま触りたくないな。";
        itemExplain[8] = "これはなんだろう？中に少し液体が入っているようだ。";
        itemExplain[9] = "これは多分紙幣という奴だろう。かつてはこれを用いて取引を行っていたようだ。";
        itemExplain[10] = "中には文字が書いてある。かなり昔の文字だが意外と読めないこともない。";
        itemExplain[11] = "黒くて重い・・・。あんま考えたくはないけど多分何かを傷つけるための道具だろう。";
        itemExplain[12] = "小さいお皿だ。なんか汚いしくさい。";
        itemExplain[13] = "赤い本と似ているが内容は異なるようだ。";
        itemExplain[14] = "小さいカップだ。かわいい。これに何か入れて飲みたいな。";

        itemFrameEffect = transform.Find("ItemFrameEffect").gameObject;
        itemFrame1 = transform.Find("ItemFrame1").gameObject;
        itemFrame2 = transform.Find("ItemFrame2").gameObject;
        itemFrame6 = transform.Find("ItemFrame6").gameObject;
        itemWindowImage2 = transform.Find("ItemWindow2/ItemWindowImage2").gameObject;
        itemNameText = transform.Find("ExplainText/ItemName").gameObject;
        itemExplainText = transform.Find("ExplainText/ItemExplain").gameObject;

        frame1tr = itemFrame1.GetComponent<Transform>();
        frame2tr = itemFrame2.GetComponent<Transform>();
        frame6tr = itemFrame6.GetComponent<Transform>();

        canvasUp = GameObject.Find("CanvasUp");
        canvasUnder = GameObject.Find("CanvasUnder");

        distanceVertical = frame1tr.position.y - frame6tr.position.y;
        distanceHorizontal = frame2tr.position.x - frame1tr.position.x;

        verticalLimitUp = frame1tr.position.y;
        verticalLimitDown = verticalLimitUp - 2 * distanceVertical;
        horizontalLimitLeft = frame1tr.position.x;
        horizontalLimitRight = horizontalLimitLeft + 4 * distanceHorizontal;

        setItemNumber = -1;
    }

    // Update is called once per frame
    void Update()
    {
        isZPressed = Input.GetKeyDown(KeyCode.Z);
        isUpPressed = Input.GetKeyDown(KeyCode.UpArrow);
        isDownPressed = Input.GetKeyDown(KeyCode.DownArrow);
        isRightPressed = Input.GetKeyDown(KeyCode.RightArrow);
        isLeftPressed = Input.GetKeyDown(KeyCode.LeftArrow);

        frameeffetr = itemFrameEffect.GetComponent<Transform>();

        ItemSelectKai();

        if (isZPressed)
        {
            ExchangeItem(itemWindowImage2);
        }

        DisplayItemExplain();
    }

    void ItemSelectKai()
    {
        if (isUpPressed)
        {
            if (Mathf.Abs(frameeffetr.position.y - verticalLimitUp) < bitError)
            {
                return;
            }
            else
            {
                y = y - 1;
                MoveEffect();
            }
        }

        if (isDownPressed)
        {
            if (Mathf.Abs(frameeffetr.position.y - verticalLimitDown) < bitError)
            {
                return;
            }
            else
            {
                y = y + 1;
                MoveEffect();
            }
        }

        if (isRightPressed)
        {
            if (Mathf.Abs(frameeffetr.position.x - horizontalLimitRight) < bitError)
            {
                return;
            }
            else
            {
                x = x + 1;
                MoveEffect();
            }
        }

        if (isLeftPressed)
        {
            if (Mathf.Abs(frameeffetr.position.x - horizontalLimitLeft) < bitError)
            {
                return;
            }
            else
            {
                x = x - 1;
                MoveEffect();
            }
        }
    }

    void MoveEffect()
    {
        frameeffetr.position = new Vector3(frame1tr.position.x + distanceHorizontal * x, frame1tr.position.y - distanceVertical * y, frame1tr.position.z);
    }

    int ReturnSelectItem(int x, int y)
    {
        int itemNumber = 5 * y + x + 1;
        return itemNumber;
    }

    void ExchangeItem(GameObject itemWindowImageX)
    {
        int itemNumber = ReturnSelectItem(x, y);
        if (canvasUp.GetComponent<ItemFrame>().itemGet[itemNumber-1])
        {
            GameObject itemFrameXItem = transform.Find("ItemFrame" + itemNumber + "/Item").gameObject;
            itemWindowImageX.GetComponent<Image>().sprite = itemFrameXItem.GetComponent<Image>().sprite;
            itemWindowImageX.GetComponent<Image>().SetNativeSize();
            Image image = itemWindowImageX.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);

            GameObject itemWindowImage1 = GameObject.Find("ItemWindowImage1");
            itemWindowImage1.GetComponent<Image>().sprite = itemFrameXItem.GetComponent<Image>().sprite;
            itemWindowImage1.GetComponent<Image>().SetNativeSize();
            image = itemWindowImage1.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
            setItemNumber = itemNumber - 1;
        }
    }

    void DisplayItemExplain()
    {
        int itemNumber = ReturnSelectItem(x, y);

        if (canvasUp.GetComponent<ItemFrame>().itemGet[itemNumber-1])
        {
            itemNameText.GetComponent<Text>().text = itemName[itemNumber - 1];
            itemExplainText.GetComponent<Text>().text = itemExplain[itemNumber - 1];
        }
        else
        {
            itemNameText.GetComponent<Text>().text = "?????";
            itemExplainText.GetComponent<Text>().text = "まだみつけていないようだ。";
        }
    }
}
