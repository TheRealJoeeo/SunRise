using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUppable : MonoBehaviour
{
    // boolean to detect if touching player
    private bool touching = false;
    // boolean to ensure the thingy in the update loop only runs once
    private bool ranAlready = false;
    // get the canvas object that shows the "press f to pick up" message
    private GameObject dialogue;

    //runs once at start
    void Start()
    {
        // find the object, since we can't just do it in the inspector since these things are prefabs
        dialogue = GameObject.Find("PickUpDialogue");
    }

    // runs every frame
    void Update() {
        // this only runs once becuase of the boolean
        if (!ranAlready) {
            // makes the dialogue hidden at start; done here becuase for some reason it was setting the object to null when doing it at start; probably some initialization problem
            dialogue.SetActive(false);
            // make it only run once
            ranAlready = true;
        }
        // check if touching the player
        if (touching)
        {
            // check if F is pressed when touching player
            if(Input.GetKeyDown(KeyCode.F))
            {
                // commit die (delete this object)
                Destroy(gameObject);
                // to add: do the thing to add it to inventory
            }
        }
    }
  
    // when an object enters this collider
     void OnTriggerEnter2D(Collider2D other) {
         // check if that object is player
         if (other.tag == "Player") {
            // j debug
            Debug.Log("Press F to pick up");
            // get the dialogue thingy, make sure it isnt null so no error, then make it show
            if (dialogue != null) dialogue.SetActive(true);
            // update the touching property to true, becuase now its touching
            touching = true;
        }
     }
     
     // once that object is not in the collider
     void OnTriggerExit2D(Collider2D other) {
         // check if player
         if (other.tag == "Player") {
            Debug.Log("Can't anymore");
            // hide the dialgoue
            if (dialogue != null) dialogue.SetActive(false);
            // update the is touching property
            touching = false;
        }
     }
}
