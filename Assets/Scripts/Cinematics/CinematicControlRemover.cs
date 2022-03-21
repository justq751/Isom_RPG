using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using RPG.Core;
using RPG.Control;

namespace RPG.Cinematics
{
    public class CinematicControlRemover : MonoBehaviour
    {
        GameObject player;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
        }

        private void DisableControl(PlayableDirector pd)
        {
            player.GetComponent<ActionScheduler>().CanceCurrentAction();
            player.GetComponent<PlayerController>().enabled = false;
        }

        private void EnableControl(PlayableDirector pd)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerController>().enabled = true;
        }
    }
}