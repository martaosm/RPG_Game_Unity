using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class NPC1 : MonoBehaviour
    {
        public GameObject triggerText;
        public GameObject DialogueObject;
        public RigidbodyFirstPersonController rb;
        public bool hasTalked = false;
        public bool isInDialogue = false;
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && !isInDialogue)
            {
                triggerText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isInDialogue = true;
                    if (!hasTalked)
                    {
                        triggerText.SetActive(false);
                        other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1;
                        DialogueObject.SetActive(true);
                        rb.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                    else
                    {
                        triggerText.SetActive(false);
                        other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1.5f;
                        DialogueObject.SetActive(true);
                        rb.enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            triggerText.SetActive(false);
        }
    }
}
