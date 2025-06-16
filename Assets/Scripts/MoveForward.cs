using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody rbEnemy;
    private Vector3 moveForward;
    private bool hasJustTurned = false;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        rbEnemy.velocity = transform.forward.normalized * speed;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bound") && !hasJustTurned)
        {
            Quaternion newRotation = Quaternion.Euler(0, 180, 0);
            rbEnemy.MoveRotation(rbEnemy.rotation * newRotation);
            rbEnemy.velocity = Vector3.zero;
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
