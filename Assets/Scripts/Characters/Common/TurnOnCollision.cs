using UnityEngine;

public class TurnOnCollision : MonoBehaviour
{
    [SerializeField] private Vector3 turnRotation = new Vector3(0, 180, 0);
    [SerializeField] private string tag = "Bound";

    private Rigidbody rb;
    private bool hasJustTurned = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (collision.gameObject.CompareTag(tag))
        {
            hasJustTurned = false;
        }
    }
}
