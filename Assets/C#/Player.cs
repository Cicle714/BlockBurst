using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float Speed; //移動スピード

    [SerializeField]
    private float ForceX; //弾に加えるXの力
    [SerializeField]
    private float ForceZ; //弾に加えるZの力
    [SerializeField]
    private float DashSpeed; //ダッシュの倍率
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector3.zero; //操作していないとき力を消す

        //操作処理
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = Vector3.left * Speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = Vector3.right * Speed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.linearVelocity *= DashSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //弾に触れた時
        if (collision.gameObject.GetComponent<Bullet>())
        {
            collision.gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(BulletForce(collision.gameObject), 0, ForceZ);
        }
    }

    float BulletForce(GameObject obj)
    {
        //弾に加えるXの力の計算 *プレイヤーの左側に触れたら、左に力を加える*
        return ((obj.transform.position.x - transform.position.x) * ForceX) + obj.GetComponent<Rigidbody>().linearVelocity.x;
    }
}
