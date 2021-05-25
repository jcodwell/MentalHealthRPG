using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NPCDialogueModel
{
public Items[] Items; 

}

[Serializable]
public class Choices
{
   public string choice;

   public int ExtNode;
}

[Serializable]
public class Dialogue
{
   public string fullName; 
   public string line; 
   public Choices[] choices; 
}

[Serializable]
public class Items
{
   public int node;
   public Dialogue[] dialogue;
}



