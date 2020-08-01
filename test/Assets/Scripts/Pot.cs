using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        anim.SetBool("smash", true); // set smash true, because transitions are made in animation 
        StartCoroutine(breakco()); // start break routine 
    }

    IEnumerator breakco()
    {
        yield return new WaitForSeconds(0.3f); // wait for 3 sec
        this.gameObject.SetActive(false); // deactivate the object
    }
}
