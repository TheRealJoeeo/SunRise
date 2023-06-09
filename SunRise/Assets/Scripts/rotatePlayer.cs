using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlayer : MonoBehaviour
{
    [SerializeField] private healthControl plyHPScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plyHPScript.getLife())
        {
            // rotate the player using some "fancy" trig to point it towards the mouse
            Vector3 ObjPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - ObjPos;
            float z = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, -z);
        }
    }
}
