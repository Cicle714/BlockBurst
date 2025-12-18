using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player player;
    GameManager gameManager;

    Rigidbody rb;

    private bool GameOver; //ゲームオーバー処理

    private void Start()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(5, 0, 10); //最初に加える力
    }

    private void Update()
    {
        //ゲームオーバー処理
        if (player.transform.position.z - 1 > transform.position.z)
        {
            if (!GameOver)
            {
                GameOver = true;
                gameManager.StartCoroutine(gameManager.GameOver());
            }
        }
    }
}
