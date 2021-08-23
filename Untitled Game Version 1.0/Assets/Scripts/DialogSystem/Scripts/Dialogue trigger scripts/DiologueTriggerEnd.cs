using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiologueTriggerEnd : MonoBehaviour
{

[SerializeField] private GameObject dialogueImage;




void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("End script Hit");
    
   
    dialogueImage.gameObject.SetActive(false);
}

}
