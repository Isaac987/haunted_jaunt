using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    public ParticleSystem FlameStream;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            FlameStream.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            FlameStream.Stop();
        }
    }
}
