using UnityEngine;

public class PassGame : MonoBehaviour
{
    public AudioSource source;
    public GameObject panel;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            if (source != null && clip != null)
                source.PlayOneShot(clip);
        }
    }
}

