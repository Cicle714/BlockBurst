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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
