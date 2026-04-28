using UnityEngine;
using UnityEngine.Animations;

public class CarVroom : MonoBehaviour, MouseAct
{
    float Hmove, Vmove;

    public GameObject player;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Hmove = Input.GetAxis("Horizontal") * 10;
        Vmove = Input.GetAxis("Vertical") * 10;

        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(Hmove, 0, Vmove);
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
