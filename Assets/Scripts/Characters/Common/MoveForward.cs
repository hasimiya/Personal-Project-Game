using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;
    private bool isMoving = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.velocity = transform.forward.normalized * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    public void StopMoving()
    {
        isMoving = false;
    }
}