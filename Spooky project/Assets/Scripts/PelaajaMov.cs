using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class PelaajaMov : MonoBehaviour
{
    [Header("Movement")]
    public float moveSPD;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;
    float horizontalImput;
    float verticalImput;
    Vector3 moveDirection;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void playerImput()
    {
        horizontalImput = Input.GetAxisRaw("Horizontal");
        verticalImput = Input.GetAxisRaw("Vertical");
    }

    private void movePlayer()
    {
        //Move calculation
        moveDirection = orientation.forward * verticalImput + orientation.right * horizontalImput;

        rb.AddForce(moveDirection.normalized * moveSPD * 10f, ForceMode.Force);
    }

    private void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        playerImput();
        SpeedConntrol();

        //drag
        if (grounded)
            rb.linearDamping = groundDrag;
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void SpeedConntrol()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVel.magnitude > moveSPD)
        {
            Vector3 limitedVel = flatVel.normalized * moveSPD;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
}
