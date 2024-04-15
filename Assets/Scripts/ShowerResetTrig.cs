using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerResetTrig : MonoBehaviour
{
    public GameObject ShowerGhost;
    public ParticleSystem particleSystem;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ShowerFlag.Flag == false)
        {
             particleSystem.Play();
            // Toggle the visibility of the MeshRenderer
            ShowerGhost.GetComponent<SkinnedMeshRenderer>().enabled = true;
            ShowerFlag.Flag = true;
        }
    }
}
