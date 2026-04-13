using UnityEngine;

public class Billboard : MonoBehaviour
{

    private Transform cam;

    //Billboard script to make the solider sprite always face the camera so it's position is always clear to the player
    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if (!cam) return;

        Vector3 direction = cam.position - transform.position;

        direction.y = 0;

        if (direction.sqrMagnitude < 0.001f) return;

        transform.rotation = Quaternion.LookRotation(direction);

        // Flip because quad faces backwards
        transform.Rotate(0f, 180f, 0f);
    }
}

