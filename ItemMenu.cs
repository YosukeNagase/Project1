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
    GameObject itemFrame1; // �t���[���̊�_
    GameObject itemFrame2; // ���ړ��̋����c��
    GameObject itemFrame6; // �c�ړ��̋����c��
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
        itemName[0] = "�Z���n��";
        itemName[1] = "����";
        itemName[2] = "�O�p��K";
        itemName[3] = "�J�M";
        itemName[4] = "�A�ؔ�";
        itemName[5] = "�ʎ�̂���";
        itemName[6] = "CD�P�[�X";
        itemName[7] = "�o�P�c";
        itemName[8] = "���C�^�[";
        itemName[9] = "100���~";
        itemName[10] = "�Ԃ��{";
        itemName[11] = "�n���h�K��";
        itemName[12] = "�D�M";
        itemName[13] = "���{";
        itemName[14] = "�e�B�[�J�b�v";

        itemExplain[0] = "�Ȃɂ��d�ʂ������ĉs���Ƃ��낪����B\n�@������ΐƂ����̂Ȃ�󂹂��������E�E�E�B";
        itemExplain[1] = "�V�����ɋ��܂��Ă��������B�E���ɂ͔��A����ɂ͊��������Ă���B\n�������B���Ă��邱�Ƃ�\���Ă���̂��낤���B";
        itemExplain[2] = "�傫���O�p�`�̕��̂��B�Ȃɂ�琔���������ς������Ă���p�r�͎v�����Ȃ��B";
        itemExplain[3] = "�ǂ����̃J�M���ۂ��B�����h�A�̌����Ǝv����B\n�ł�" +
            "�Ȃ�ł������Ă킽��������ȂƂ��ɕ����߂��̂��낤�B";
        itemExplain[4] = "�A�����A���Ă���B����ȏ������̂ɓ���ĉ��̈Ӗ�������̂��낤���H������Ϗܗp�Ƃ�������낤���B";
        itemExplain[5] = "�Ȃ񂩂߂�����|���B�l�̊���Ă���Ȃ����������H�T�C�Y�I�ɂ͎��̊��肿����Ƒ傫�����炢���E�E�E�B";
        itemExplain[6] = "�����ȃP�[�X�Ɠ��F�Ɍ��锖���~�Ղ��B�Ȃ�炩�̓d�q�@��Ɋւ�����̂��낤����̂���ŉ����ł���񂾂낤�B";
        itemExplain[7] = "��F�̒ꂪ�[�߂̊킾�B����܂��Y�킶��Ȃ��݂����ŁA�����ɂ͉��ꂪ����B����ܐG�肽���Ȃ��ȁB";
        itemExplain[8] = "����͂Ȃ񂾂낤�H���ɏ����t�̂������Ă���悤���B";
        itemExplain[9] = "����͑��������Ƃ����z���낤�B���Ă͂����p���Ď�����s���Ă����悤���B";
        itemExplain[10] = "���ɂ͕����������Ă���B���Ȃ�̂̕��������ӊO�Ɠǂ߂Ȃ����Ƃ��Ȃ��B";
        itemExplain[11] = "�����ďd���E�E�E�B����܍l�������͂Ȃ����Ǒ��������������邽�߂̓���낤�B";
        itemExplain[12] = "���������M���B�Ȃ񂩉������������B";
        itemExplain[13] = "�Ԃ��{�Ǝ��Ă��邪���e�͈قȂ�悤���B";
        itemExplain[14] = "�������J�b�v���B���킢���B����ɉ�������Ĉ��݂����ȁB";

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
            itemExplainText.GetComponent<Text>().text = "�܂��݂��Ă��Ȃ��悤���B";
        }
    }
}
