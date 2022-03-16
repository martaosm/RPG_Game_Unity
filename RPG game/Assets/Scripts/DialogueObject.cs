using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class DialogueObj
    {
        public string[] Dialogues;
        public string CharacterName;
    }

    public class DialogueObject : MonoBehaviour
    {
        public PlayerData data;
        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] TextMeshProUGUI DialogueText;
        [SerializeField] Text buttonText;
        public GameObject DialogueBox;
        public RigidbodyFirstPersonController rb;


        private QuestObject obj;
        private int currentDialogueNumber = 0;
        private DialogueObj curDialogue = null;

        [Header("Dialogue objects")]
        public DialogueObj dialogue1;
        public DialogueObj dialogue1o5;

        [Header("NPCS")]
        public NPC1 npc1;

        private void Awake()
        {
            obj = FindObjectOfType<QuestObject>();
        }
        private void OnEnable()
        {
            switch (data.DialogueNumber)
            {
                case 1:
                    PlayDialogue(dialogue1);
                    curDialogue = dialogue1;
                    break;
                case 1.5f:
                    PlayDialogue(dialogue1o5);
                    curDialogue = dialogue1o5;
                    break;

            }
        }

        void PlayDialogue(DialogueObj temp)
        {
            nameText.text = temp.CharacterName;
            if (currentDialogueNumber == 0)
            { 
                buttonText.text = "Skip";
            }
            if (currentDialogueNumber < temp.Dialogues.Length)
            {
                DialogueText.text = temp.Dialogues[currentDialogueNumber];
                if (currentDialogueNumber == temp.Dialogues.Length - 1)
                {
                    buttonText.text = "Exit";
                }
            }
            else 
            {
                this.gameObject.SetActive(false);
                rb.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                switch (data.DialogueNumber)
                {
                    case 1:
                        npc1.hasTalked = true;
                        npc1.isInDialogue = false;
                        obj.StartNewQuest(obj.quests[0]);
                        break;
                    case 1.5f:
                        npc1.isInDialogue = false;
                        break;
                }
                data.DialogueNumber = 0;
                currentDialogueNumber = 0;
                //data.questNumber = curDialogue.questNumber;
                curDialogue = null;
                this.gameObject.SetActive(false);

            }

        }
        public void next()
        {
            if (curDialogue != null)
            {
                currentDialogueNumber++;
                PlayDialogue(curDialogue);
            }
        }
    }
}
