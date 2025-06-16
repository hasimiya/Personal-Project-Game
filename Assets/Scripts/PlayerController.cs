using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        //Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput);

        // Нормализуем, чтобы длина всегда была 1 (или 0, если игрок не двигается)
        Vector3 newPositionPlayer = inputDirection.normalized * speed;

        rbPlayer.AddForce(newPositionPlayer);
    }
}
