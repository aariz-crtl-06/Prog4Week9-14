using UnityEngine;

public class CamHolder : MonoBehaviour
{

    public Transform cameraPosition;
    void Start()
    {

    }

    // Hold the camera
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}