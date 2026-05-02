using UnityEngine;
using UnityEngine.Animations;

public class CarVroom : MonoBehaviour, MouseAct
{
    float Hmove, Vmove;
    public float speed = 2f;
    public float turnSpeed = 2f;
    public float maxSpeed = 20f;
    public float maxTurnSpeed = 2f;

    public GameObject player;
    public TMPro.TextMeshProUGUI text;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rb.isKinematic)
        {
            Vector3 localInput = new Vector3(Hmove * speed, 0f, Vmove * speed);
            Vector3 worldVel = transform.TransformDirection(localInput);
            worldVel.y = rb.velocity.y; // preserve current world-space vertical velocity
            rb.velocity = worldVel;
        }

        Hmove = Input.GetAxis("Horizontal") * 2;
        Vmove = Input.GetAxis("Vertical") * 2;

        Debug.Log("Hmove: " + Hmove + " Vmove: " + Vmove);

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        if(rb.angularVelocity.magnitude > maxTurnSpeed)
        {
            rb.angularVelocity = rb.angularVelocity.normalized * maxTurnSpeed;
        }
        text.text = rb.velocity.magnitude.ToString("F2") + " MPH";
    }

    void MouseAct.OnClickAction()
    {
        rb.isKinematic = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Collider>().enabled = false;
        player.GetComponent<CameraMovement>().enabled = false;
        player.transform.position = transform.position;
        player.transform.rotation = transform.rotation;
        player.transform.SetParent(transform);

    }
}
