using UnityEngine;

public class Framerate : MonoBehaviour
{

    public int framerate = 60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = framerate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
