using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static DialougeSerializerScript;

public class DialougeSerializerTestingScript : MonoBehaviour
{

    
void start()
{

}
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        DialougeSerializerScript script = new DialougeSerializerScript();
        DialougeDetails details = new DialougeDetails();
        details.Name = "Test";
        details.Dialouge = "Test";
        details.DialougeDestination = 1;
        Console.WriteLine("create dialouge");
        Debug.Log(details.Name + details.Dialouge + details.DialougeDestination);
        Debug.Log("Space key was pressed.");
        script.createXML(details, "text.xml");

        
        }

          if (Input.GetKeyDown(KeyCode.S))
        {
          
          Console.WriteLine("To create save");
          Debug.Log("S key was pressed.");

        }

        
          if (Input.GetKeyDown(KeyCode.L))
        {
          //DialougeSerializerScript.LoadDialogue("test.xml");
          DialougeSerializerScript script = new DialougeSerializerScript();
          script.LoadDialogue("test.xml");
          Console.WriteLine("create load");
          Debug.Log("L key was pressed.");

        }
    }
    
}
