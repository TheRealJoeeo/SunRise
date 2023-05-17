using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUppable : MonoBehaviour
{
    private bool touching = false;
    private bool ranAlready = false;
    private GameObject dialogue;

    void Start()
    {
        dialogue = GameObject.Find("PickUpDialogue");
    }

    void Update() {
        if (!ranAlready) {
            dialogue.SetActive(false);
            ranAlready = true;
        }
        if(Input.GetKeyDown (KeyCode.F))
        {
          if (touching)
            Destroy(gameObject);
        }
    }
  
     void OnTriggerEnter2D(Collider2D other) {
         if (other.tag == "Player") {
            Debug.Log("Press F to pick up");
            if (dialogue != null) dialogue.SetActive(true);
            touching = true;
        }
     }
     
     void OnTriggerExit2D(Collider2D other) {
         if (other.tag == "Player") {
            Debug.Log("Can't anymore");
            if (dialogue != null) dialogue.SetActive(false);
            touching = false;
        }
     }
}
