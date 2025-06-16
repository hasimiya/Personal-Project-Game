using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody rbEnemy;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveForward = transform.forward.normalized;
        rbEnemy.AddForce(moveForward * speed);
    }
}
