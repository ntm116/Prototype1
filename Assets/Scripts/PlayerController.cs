using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float horsePower = 10000f;

    [SerializeField]
    private float turnSpeed;

    [SerializeField]
    private float horizontalInput;

    [SerializeField]
    private float verticalInput;

    [SerializeField]
    private GameObject centerOfMass;

    [SerializeField]
    private TextMeshProUGUI speedometerText;

    [SerializeField]
    private TextMeshProUGUI rpmText;

    [SerializeField]
    private List<WheelCollider> allWheels;

    private Rigidbody playerRb;

    private float speed;
    private float rpm;
    [SerializeField]
    private int wheelsOnTheGround;

    private const float MPH_Coefficent = 2.237f;
    private const float KPH_Coefficent = 3.6f;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move player
        if (IsGrounded())
        {
            playerRb.AddRelativeForce(verticalInput * horsePower * Vector3.forward);

            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
    }

    private void Update()
    {
        speed = Mathf.Round( playerRb.velocity.magnitude * MPH_Coefficent);
        speedometerText.SetText("Speed: " + speed + "mph");

        rpm = Mathf.Round(speed % 30 * 40);
        rpmText.SetText("RPM: " + rpm);
    }

    bool IsGrounded()
    {
        wheelsOnTheGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded) wheelsOnTheGround += 1;
        }
        

        if (wheelsOnTheGround > 3)
            return true;
        return false;
    }
}
