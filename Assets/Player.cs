using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float Speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity=Vector3.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = Vector3.left * Speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = Vector3.right * Speed;
        }
    }
}
