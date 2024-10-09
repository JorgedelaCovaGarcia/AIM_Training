using UnityEngine;

public class SphereController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnHit()
    {
        audioSource.Play();        
        Destroy(gameObject, audioSource.clip.length); 
    }
}
