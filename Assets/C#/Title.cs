using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField]
    private Image BlackOut; //暗転用

    [SerializeField]
    private Text PushText; //[Push To Enter]の点滅用
    [SerializeField]
    private float PushInterval; //点滅の間隔
    private bool Push; //ボタンを押した
    private float PushCount; //点滅のカウント
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TitleStart()); //タイトルの暗転処理
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!Push)
            {
                StartCoroutine(GameStart()); //ゲーム開始の処理
            }
            Push = true;

        }

        if (Push)
        {
            PushCount -= Time.deltaTime * 4; //ボタン押したら点滅の間隔を速くする
        }
        else
        {
            PushCount -= Time.deltaTime; //点滅用
        }
        //点滅処理
        if (PushCount < 0)
        {
            PushCount = PushInterval;
            if (PushText.color.a != 0)
                PushText.color = new Color(1, 1, 1, 0);
            else
                PushText.color = new Color(1, 1, 1, 1);
        }
    }

    /// <summary>
    /// タイトルの最初
    /// </summary>
    /// <returns></returns>
    IEnumerator TitleStart()
    {
        while (BlackOut.color.a > 0)
        {
            BlackOut.color -= new Color(0, 0, 0, Time.deltaTime);
            yield return null;
        }
    }
    /// <summary>
    /// プレイシーンに移動
    /// </summary>
    /// <returns></returns>
    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1f);
        while (BlackOut.color.a <= 1)
        {
            BlackOut.color += new Color(0, 0, 0, Time.deltaTime);
            yield return null;
        }
        SceneManager.LoadScene("PlayScene");
    }
}
