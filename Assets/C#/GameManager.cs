using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Text GameOverText; //ゲームオーバーテキスト
    [SerializeField]
    private Text GameClearText; //ゲームクリアテキスト
    [SerializeField]
    private Image BlackOut; //暗転用

    void Start()
    {
        StartCoroutine(GameStart()); //暗転処理
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 暗転処理
    /// </summary>
    /// <returns></returns>
    IEnumerator GameStart()
    {
        while (BlackOut.color.a > 0)
        {
            BlackOut.color -= new Color(0, 0, 0, Time.deltaTime * 2f);
            yield return null;
        }
    }

    /// <summary>
    /// ゲームオーバー時の処理
    /// </summary>
    /// <returns></returns>
    public IEnumerator GameOver()
    {
        while (GameOverText.color.a < 1)
        {
            GameOverText.color += new Color(0, 0, 0, Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        while (BlackOut.color.a < 1)
        {
            BlackOut.color += new Color(0, 0, 0, Time.deltaTime * 2f);
            yield return null;
        }
        if (BlackOut.color.a >= 1)
        {
            SceneManager.LoadScene("Title");
        }
    }
    /// <summary>
    /// ゲームクリア時の処理
    /// </summary>
    /// <returns></returns>
    public IEnumerator GameClear()
    {
        while (GameClearText.color.a < 1)
        {
            GameClearText.color += new Color(0, 0, 0, Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        while (BlackOut.color.a < 1)
        {
            BlackOut.color += new Color(0, 0, 0, Time.deltaTime * 2f);
            yield return null;
        }
        if (BlackOut.color.a >= 1)
        {
            SceneManager.LoadScene("Title");
        }
    }

}
