using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeHelp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // if x pressed, close help dialogue
        if (Input.GetKeyDown(KeyCode.X))
        {
            Destroy(gameObject);
        }
    }
}
