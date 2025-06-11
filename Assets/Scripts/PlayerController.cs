using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;

    [SerializeField] private float gravityModifier = 1f;

    private float xRangePlayer = 24f;
    private float zRangePlayer = 13f;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Vector3 moveHorizontal = Vector3.right * horizontalInput * speed * Time.deltaTime;
        Vector3 moveVertical = Vector3.forward * verticalInput * speed * Time.deltaTime;
        Vector3 newPositionPlayer = rbPlayer.position + moveHorizontal + moveVertical;

        newPositionPlayer.x = Mathf.Clamp(newPositionPlayer.x, -xRangePlayer, xRangePlayer);
        newPositionPlayer.z = Mathf.Clamp(newPositionPlayer.z, -zRangePlayer, zRangePlayer);

        rbPlayer.MovePosition(newPositionPlayer);

    }
}
