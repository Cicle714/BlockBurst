using UnityEngine;

public class Block : MonoBehaviour
{

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //íeÇ…ìñÇΩÇ¡ÇΩÇÁè¡Ç∑èàóù
        if (collision.gameObject.GetComponent<Bullet>())
        {
            FindObjectOfType<BlockSpawner>().BlockNum--;
            Destroy(gameObject);
        }
    }


}
