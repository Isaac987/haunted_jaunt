using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplTrigger : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public GameObject ShowerGhost;
    public AudioClip soundEffect;

    private AudioSource audioSource;

    void Start()
    {
        // Get AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ShowerFlag.Flag == true)
        {          
            particleSystem.Play();
            audioSource.PlayOneShot(soundEffect);
            // Toggle the visibility of the MeshRenderer
            ShowerGhost.GetComponent<SkinnedMeshRenderer>().enabled = false;
            ShowerFlag.Flag = false;
        }
    }
}
