using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(5,0,10);
    }
}
