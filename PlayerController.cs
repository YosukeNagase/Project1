using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject textFrame;
    public GameObject menuPanel;

    public AudioSource audioSource;

    // 移動スピード
    public float playerSpeed = 3.0f;

    // アニメーション名
    public string upAnime = "PlayerUp";
    public string downAnime = "PlayerDown";
    public string rightAnime = "PlayerRight";
    public string leftAnime = "PlayerLeft";
    public string upAnimeStop = "PlayerUpStop";
    public string downAnimeStop = "PlayerDownStop";
    public string rightAnimeStop = "PlayerRightStop";
    public string leftAnimeStop = "PlayerLeftStop";

    string nowAnimation = "";
    string oldAnimation = "";

    float axisH;
    float axisV;
    // 移動角度(弧度法)
    public float angleZ = -90.0f;

    Rigidbody2D rbody;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        oldAnimation = downAnime;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (textFrame.activeSelf == false && menuPanel.activeSelf == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");
            if (axisH != 0 || axisV != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
        else
        {
            axisH = 0;
            axisV = 0;
            if (nowAnimation == upAnime)
            {
                nowAnimation = upAnimeStop;
            }
            else if (nowAnimation == downAnime)
            {
                nowAnimation = downAnimeStop;
            }
            else if (nowAnimation == rightAnime)
            {
                nowAnimation = rightAnimeStop;
            }
            else if (nowAnimation == leftAnime)
            {
                nowAnimation = leftAnimeStop;
            }

            isMoving = false;
        }
        // 移動角度の取得
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);
        // 移動角度からアニメーションを決定
        if (angleZ >= -45 && angleZ < 45)
        {
            if (isMoving)
            {
                nowAnimation = rightAnime;
            }
            else
            {
                nowAnimation = rightAnimeStop;
            }
            
        }
        else if (angleZ >= 45 && angleZ < 135)
        {
            if (isMoving)
            {
                nowAnimation = upAnime;
            }
            else
            {
                nowAnimation = upAnimeStop;
            }
            
        }
        else if (angleZ >= -135 && angleZ < -45)
        {
            if (isMoving)
            {
                nowAnimation = downAnime;
            }
            else
            {
                nowAnimation = downAnimeStop;
            }
        }
        else
        {
            if (isMoving)
            {
                nowAnimation = leftAnime;
            }
            else
            {
                nowAnimation = leftAnimeStop;
            }
        }
        // アニメーションを切り替える
        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            GetComponent<Animator>().Play(nowAnimation);

            if (nowAnimation == leftAnime || nowAnimation == rightAnime || nowAnimation == upAnime || nowAnimation == downAnime)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    void FixedUpdate()
    {
        // 移動速度の更新
        rbody.velocity = new Vector2(axisH, axisV) * playerSpeed;
    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        axisV = v;
        if (axisH == 0 && axisV == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            float rad = Mathf.Atan2(dy, dx);
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }
        return angle;
    }
}
