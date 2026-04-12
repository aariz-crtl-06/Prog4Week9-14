using UnityEngine;

public class CamHolder : MonoBehaviour
{

    public Transform cameraPosition;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}