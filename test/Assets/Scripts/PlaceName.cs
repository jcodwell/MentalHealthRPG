using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlaceName : MonoBehaviour // showing place name on the center of the screen
{
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (needText) // trigger needText is on then:
        {
            StartCoroutine(placeNameCo()); // start coroutine 
        }
    }

    private IEnumerator placeNameCo() // coroutine 
    {
        text.SetActive(true); // activate text, it is deactivated when started
        placeText.text = placeName; // text equals to a string name
        yield return new WaitForSeconds(4f); // wait 4 sec
        text.SetActive(false); // deactivate the text 
    }
}
