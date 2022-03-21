using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        private bool wasTriggered = false;

        private void OnTriggerEnter(Collider other)
        {
            print("Triggered by " + other.gameObject.name);
            if (other.CompareTag("Player") && !wasTriggered)
            {
                wasTriggered = true;
                GetComponent<PlayableDirector>().Play();
            }
        }
    }
}

