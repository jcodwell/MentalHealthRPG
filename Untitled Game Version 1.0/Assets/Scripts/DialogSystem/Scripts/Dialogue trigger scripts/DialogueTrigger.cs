using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
  


[SerializeField] private GameObject dialogueImage;


private void Start() {

 dialogueImage.gameObject.SetActive(false);

}

void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Hit");
    
   
    dialogueImage.gameObject.SetActive(true);
}


}
