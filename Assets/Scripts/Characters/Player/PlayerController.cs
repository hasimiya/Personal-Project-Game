using UnityEngine;

public class PlayerController : Character // INHERITANCE Child Class
{
    private float horizontalInput;
    private float verticalInput;

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
