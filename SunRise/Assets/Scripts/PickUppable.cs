using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUppable : MonoBehaviour
{
    private bool touching = false;
     void Update () {
        if(Input.GetKeyDown (KeyCode.F))
        {
          if (touching)
            Destroy(gameObject);
        }
     }
  
     void OnTriggerEnter2D(Collider2D other) {
         if (other.tag == "Player") {
            Debug.Log("Press F to pick up");
            touching = true;
         }
     }
     
     void OnTriggerExit2D(Collider2D other) {
         if (other.tag == "Player") {
            Debug.Log("Can't anymore");
            touching = false;
         }
     }
}
