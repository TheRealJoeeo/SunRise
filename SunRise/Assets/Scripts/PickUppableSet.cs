using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUppableSet : MonoBehaviour
{
    // boolean to detect if touching player
    private bool touching = false;
    // boolean to ensure the thingy in the update loop only runs once
    private bool ranAlready = false;
    // get the canvas object that shows the "press f to pick up" message
    private GameObject dialogue;
    private GameObject whatIAm;

    //runs once at start
    void Start()
    {
        // find the object, since we can't just do it in the inspector since these things are prefabs
        dialogue = GameObject.Find("DialogueHolder").GetComponent<DialogueHolder>().PickUp;
    }

    public void setWhatIAm(GameObject wia)
    {
        whatIAm = wia;
    }

    // runs every frame
    void Update()
    {
        // this only runs once becuase of the boolean
        if (!ranAlready)
        {
            // makes the dialogue hidden at start; done here becuase for some reason it was setting the object to null when doing it at start; probably some initialization problem
            dialogue.SetActive(false);
            // make it only run once
            ranAlready = true;
        }
        // check if touching the player
        if (touching)
        {
            // check if F is pressed when touching player
            if (Input.GetKeyDown(KeyCode.F) && GameObject.Find("Inventory").GetComponent<inventoryControl>().getActive() == "empty")
            {
                // if the object is tagged as a weapon, we spawn it in to the player.
                // If it doesnt have a weapon tag, we will eventually check if its armor,
                // which will also be spawned to the player, but in a different way so
                // we'd have a different else if statement, and we'd also have one for
                // if its not tagged any of those kind of things (ie if it was a medkit)
                // and then it would do the code accordingly to what it is
                // (so like if its a medkit itll add 1 to the medkit counter in the
                // inventory script (when we make it))

                if (whatIAm.tag == "weapon")
                {
                    whatIAm.SetActive(true);
                    GameObject temp = Instantiate(whatIAm, new Vector3(0, 0, 1), transform.rotation);
                    temp.transform.SetParent(GameObject.Find("PlayerGraphicsAndFistHitbox").transform, false);
                }

                // commit die (delete this object)
                Destroy(whatIAm);
                Destroy(gameObject);
            }
        }
    }

    // when an object enters this collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // check if that object is player
        if (other.tag == "Player")
        {
            // j debug
            Debug.Log("Press F to pick up");
            // get the dialogue thingy, make sure it isnt null so no error, then make it show
            if (dialogue != null) dialogue.SetActive(true);
            // update the touching property to true, becuase now its touching
            touching = true;
        }
    }

    // once that object is not in the collider
    void OnTriggerExit2D(Collider2D other)
    {
        // check if player
        if (other.tag == "Player")
        {
            Debug.Log("Can't anymore");
            // hide the dialgoue
            if (dialogue != null) dialogue.SetActive(false);
            // update the is touching property
            touching = false;
        }
    }
}
