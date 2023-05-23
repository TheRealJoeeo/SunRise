using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    private objectDamageControl dmgScript;
    private bool breakableInTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (breakableInTrigger)
        {
            // variable bullet daamage would be applied here
            if (dmgScript != null) dmgScript.appDmg(2);
            Destroy(gameObject); // this doesnt work right now for some reason :\
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if that object is player
        if (other.tag == "breakable")
        {
            dmgScript = other.gameObject.GetComponent<objectDamageControl>();
            breakableInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // check if that object is player
        if (other.tag == "breakable")
        {
            breakableInTrigger = false;
        }
    }
}
