using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson 
{
    public class escaped : MonoBehaviour
    {
        public GameObject playerObject;
        public GameObject escapeScreen;
        private Rigidbody playerRB;
        private bool playerEscaped = false;
        private bool escapedAction = false;

        void Start()
        {
            playerRB = playerObject.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (playerEscaped && !escapedAction)
            { // display escaped menu
                playerObject.GetComponent<FirstPersonController>().enabled = false;
                escapeScreen.SetActive(true);
            }
        }
        // player has escaoed.
        private void OnTriggerEnter(Collider other)
        {
            Rigidbody body = other.GetComponent<Rigidbody>();

            if (body == playerRB)
            {
                playerEscaped = true;
            }
        }

    }

}
