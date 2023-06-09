using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fistControl : MonoBehaviour
{
    [SerializeField] private healthControl plyHPScript;

    private zombieControl zombieScript;
    private objectDamageControl dmgScript;
    private ObjectWithDropControl dmgScriptAlt;
    private bool breakableInTrigger;

    private Vector2 localLocalR;
    private Vector2 localLocalL;
    [SerializeField] private GameObject Rfist;
    [SerializeField] private GameObject Lfist;

    [SerializeField] private float punchDelay;

    private AudioSource a;

    // private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        localLocalR = new Vector2(0, 0);
        localLocalL = new Vector2(0, 0);

        a = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plyHPScript.getLife())
        {
            // meelee mode
            if (GameObject.Find("Inventory").GetComponent<inventoryControl>().getActive() == "empty")
            {

                // right
                localLocalR *= 0.9f;
                Rfist.transform.localPosition = new Vector2((localLocalR.x + 0.4f), (localLocalR.y + 0.4f));
                // left
                localLocalL *= 0.9f;
                Lfist.transform.localPosition = new Vector2((localLocalL.x - 0.4f), (localLocalL.y + 0.4f));

                if (Input.GetMouseButtonDown(0)) // if mouse clicked, pucnh
                {
                    gameObject.GetComponent<Collider2D>().enabled = true; // get collider ready to check if collision to do damage

                    // fist sound, and then fist punch animation (randomnized)
                    a.Play();
                    int temp = Random.Range(0, 2); 

                    if (temp == 0)
                        localLocalR = new Vector2(-0.45f, 0.7f);
                    else
                        localLocalL = new Vector2(0.45f, 0.5f);

                    if (breakableInTrigger) // if touching something breakable, break it
                    {
                        if (dmgScript != null) dmgScript.appDmg(1);
                        else if (dmgScriptAlt != null) dmgScriptAlt.appDmg(1);
                        else if (zombieScript != null) zombieScript.appDmg(1);
                    }

                    gameObject.GetComponent<Collider2D>().enabled = false;
                    gameObject.GetComponent<Collider2D>().enabled = true;

                }
            }
            // positions for if the player is holding x type of gun
            else if (GameObject.Find("Inventory").GetComponent<inventoryControl>().getActive() == "pistol")
            {
                Lfist.transform.localPosition = new Vector2(0, 0.4f);
                Rfist.transform.localPosition = new Vector2(0, 0.4f);
            }
            else if (GameObject.Find("Inventory").GetComponent<inventoryControl>().getActive() == "rifle")
            {
                Lfist.transform.localPosition = new Vector2(0, 0.4f);
                Rfist.transform.localPosition = new Vector2(0.1f, 1f);
            }
            else if (GameObject.Find("Inventory").GetComponent<inventoryControl>().getActive() == "sniper")
            {
                Lfist.transform.localPosition = new Vector2(0, 0.4f);
                Rfist.transform.localPosition = new Vector2(0.15f, 1.5f);
            }
        }
    }

    // check when something the palyer can do damage to enters the trigger and when it leaves

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if that object is player
        if (other.tag == "breakable")
        {
            dmgScript = other.gameObject.GetComponent<objectDamageControl>();
            dmgScriptAlt = other.gameObject.GetComponent<ObjectWithDropControl>();
            zombieScript = other.gameObject.GetComponent<zombieControl>();
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
