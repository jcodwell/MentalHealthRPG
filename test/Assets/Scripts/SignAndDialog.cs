using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignAndDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange) 
        {  // when the player is in range and space is pressed 
            if (dialogBox.activeInHierarchy) // if dialogbox is active in the hierarchy  
            {
                dialogBox.SetActive(false); // set it deactive
            }
            else
            {
                dialogBox.SetActive(true); // else set it active 
                dialogText.text = dialog; // show the text 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // when player enter range, set playerinrange active
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // when player left range
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;  // set playerinrange false and deactive dialogbox
            dialogBox.SetActive(false);
        }
    }
}
