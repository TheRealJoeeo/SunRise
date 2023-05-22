using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fistControl : MonoBehaviour
{
    private objectDamageControl dmgScript;
    private bool breakableInTrigger;

    private Vector2 localLocalR;
    private Vector2 localLocalL;
    [SerializeField] private GameObject Rfist;
    [SerializeField] private GameObject Lfist;

    // Start is called before the first frame update
    void Start()
    {
        localLocalR = new Vector2(0, 0);
        localLocalL = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // right
        localLocalR *= 0.9f;
        Rfist.transform.localPosition = new Vector2((localLocalR.x + 0.4f), (localLocalR.y + 0.4f));
        // left
        localLocalL *= 0.9f;
        Lfist.transform.localPosition = new Vector2((localLocalL.x - 0.4f), (localLocalL.y + 0.4f));

        if (Input.GetMouseButtonDown(0))
        {
            int temp = Random.Range(0, 2);
            if (temp == 0)
                localLocalR = new Vector2(-0.45f, 0.7f);
            else
                localLocalL = new Vector2(0.45f, 0.7f);

            if (breakableInTrigger)
            {
                if (dmgScript != null) dmgScript.appDmg(1);
            }
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
