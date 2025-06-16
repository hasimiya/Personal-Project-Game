using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private CharacterController controller;


    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
    }
    private void FixedUpdate()
    {
        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 newPositionPlayer = inputDirection.normalized * speed;
        rbPlayer.velocity = newPositionPlayer;
        //rbPlayer.AddForce(newPositionPlayer);
    }
    void Fire()
    {
        Debug.Log("Fire!");
        Instantiate(projectilePrefab, projectileSpawnPoint.position, rbPlayer.rotation);
    }
}
