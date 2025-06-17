using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 turnRotation = new Vector3(0, 180, 0);
    [SerializeField] private string tag = "Bound";

    private Rigidbody rb;
    private bool hasJustTurned = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward.normalized * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tag) && !hasJustTurned)
        {
            Quaternion newRotation = Quaternion.Euler(turnRotation);
            rb.MoveRotation(rb.rotation * newRotation);
            rb.velocity = Vector3.zero;
            hasJustTurned = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bound"))
        {
            hasJustTurned = false;
        }
    }
}
