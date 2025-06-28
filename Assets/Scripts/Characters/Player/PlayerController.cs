using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float forceJump;

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
        Vector3 inputDirection = new(horizontalInput, 0, verticalInput);
        //Move(inputDirection);
        rbCharacter.velocity = inputDirection.normalized * speed;
    }
}
