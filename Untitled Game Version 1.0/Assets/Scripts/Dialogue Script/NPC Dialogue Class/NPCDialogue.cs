using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class NPCDialogue : MonoBehaviour
{
    string fileName;
    string jsonString;
   NPCDialogueModel[] npcDialogueObj = new NPCDialogueModel[3];

    void Start()
    {
   
        fileName = Application.dataPath + "/Scripts/Dialogue Script/NPC Dialogue Class/ACT 1 Script/Act-1_Test.json";
        jsonString = File.ReadAllText (fileName); 
        deserializer();
        
    }

    void deserializer() {
        NPCDialogueModel[] npcDialogueObj = JsonHelper.FromJson<NPCDialogueModel>(jsonString);
        //npcDialogueObj = JsonUtility.FromJson<NPCDialogueModel>(jsonString);
        Debug.Log(jsonString);
        Debug.Log(npcDialogueObj[0].Items[0].node);
    }

}
