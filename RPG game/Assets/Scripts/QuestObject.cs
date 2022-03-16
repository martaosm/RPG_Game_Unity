using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class Quest
    {
        //public string[] Dialogues;
        public string title;
        public string objective;
    }
    public class QuestObject : MonoBehaviour
    {
        public GameObject questObject;
        public TextMeshProUGUI questTitle, questObjective;
        public Quest[] quests;
        public void StartNewQuest(Quest tmp)
        {
            questTitle.text = tmp.title;
            questObjective.text = tmp.objective;
            questObject.SetActive(true);
            Invoke("CloseQuest",7f);
        }

        private void CloseQuest()
        {
            questObject.SetActive(false);
        }
    }
}
