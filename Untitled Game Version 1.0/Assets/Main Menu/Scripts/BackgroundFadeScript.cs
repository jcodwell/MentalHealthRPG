using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundFadeScript : MonoBehaviour
{
 
    public GameObject Panel;
    //public List<Image> backgroundColors = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {


        Panel.SetActive(false);

    }




 

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Panel.SetActive(true);
        }
       


    }
}
