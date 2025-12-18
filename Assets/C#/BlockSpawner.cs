using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField]
    private GameObject Block; //生成用ブロック
    [SerializeField]
    private int Width; //ブロックの横の数
    [SerializeField]
    private int Height; //ブロックの縦の数
    public int BlockNum;

    [SerializeField]
    private float Blockdistance; //ブロック同士の間隔

    private bool GameClear; //ゲームのクリア判定

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                Instantiate(Block, transform.position + new Vector3((float)((-Width / 2 + 0.5f) + j) * Blockdistance, 0, -Height / 2 + i), Quaternion.identity); //ブロック生成
                BlockNum++; //生成した数のカウント
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームクリア処理
        if (BlockNum <= 0)
        {
            FindObjectOfType<Bullet>().GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            if (!GameClear)
            {
                GameClear = true;
                gameManager.StartCoroutine(gameManager.GameClear());
            }
        }
    }
}
