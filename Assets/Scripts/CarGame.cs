using UnityEngine;

public class CarGame : MonoBehaviour
{
    public Rigidbody rb;
    public WheelCollider W1, W2, W3, W4;
    public float drivespeed, turnspeed, breakspeed;
    float Hinput, Vinput, boost;
    bool breaking = false;

    // Update is called once per frame
    void Update()
    {
        if (!breaking)
        {
            Hinput = Input.GetAxis("Horizontal");
            Vinput = Input.GetAxis("Vertical");
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            boost += drivespeed;
            rb.AddForce(transform.forward * boost * Time.deltaTime, ForceMode.VelocityChange);
        }
        W1.motorTorque = Vinput * drivespeed;
        W2.motorTorque = Vinput * drivespeed;
        W3.motorTorque = Vinput * drivespeed;
        W4.motorTorque = Vinput * drivespeed;
        W1.steerAngle = Hinput * turnspeed;
        W2.steerAngle = Hinput * turnspeed;

        if(Input.GetKey(KeyCode.Space))
        {
            breaking = true;
            //W1.brakeTorque = breakspeed;
            //W2.brakeTorque = breakspeed;
            W3.brakeTorque = breakspeed;
            W4.brakeTorque = breakspeed;
        }
        else
        {
            breaking = false;
            W1.brakeTorque = 0f;
            W2.brakeTorque = 0f;
            W3.brakeTorque = 0f;
            W4.brakeTorque = 0f;
        }
    }
}
