using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerResetTrig : MonoBehaviour
{
    public GameObject ShowerGhost;
    public ParticleSystem particleSystem;
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
        if (other.CompareTag("Player") && ShowerFlag.Flag == false)
        {
             particleSystem.Play();
            // Toggle the visibility of the MeshRenderer
            audioSource.PlayOneShot(soundEffect);
            ShowerGhost.GetComponent<SkinnedMeshRenderer>().enabled = true;
            ShowerFlag.Flag = true;
        }
    }
}
