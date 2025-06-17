using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float forceJump;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire(transform.forward);
        }
    }
    private void FixedUpdate()
    {
        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput);
        Move(inputDirection);
    }
}
