using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float speedTorque;
    private void Start()
    {
        rb.maxAngularVelocity = 5f;
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        rb.AddRelativeForce(new Vector3(0,0,x*speed),ForceMode.VelocityChange);
        if (x >= 0)
        {
            rb.AddRelativeTorque(new Vector3(0, y * speedTorque, 0), ForceMode.VelocityChange);
        }
        else
        {
            rb.AddRelativeTorque(new Vector3(0, -y * speedTorque, 0), ForceMode.VelocityChange);
        }
    }
}
