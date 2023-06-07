using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    private zombieControl zombieScript;
    private ObjectWithDropControl dmgScriptAlt;
    private objectDamageControl dmgScript;
    private bool breakableInTrigger;
    private GameObject parent;
    
    private float damage;
    private float fallOffVel;

    private int cheap = 0; // cheap way to get around the fact that the update function sometimes runs before a force is added to the bullet when it is created, which deletes it instantly since it starts at 0 velocity.

    public void setDamage(float dmg)
    {
        damage = dmg;
    }

    public void setFallOff(float falloff)
    {
        fallOffVel = falloff;
    }

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (breakableInTrigger)
        {
            // variable bullet daamage would be applied here
            if (dmgScript != null) dmgScript.appDmg(damage);
            else if (dmgScriptAlt != null) dmgScriptAlt.appDmg(damage);
            else if (zombieScript != null) zombieScript.appDmg(damage);

            Debug.Log(gameObject.transform.parent.gameObject.GetComponent<Collider2D>() != null);

            if (gameObject.transform.parent.gameObject.GetComponent<Collider2D>() != null)
                Destroy(gameObject.transform.parent.gameObject);
        }

        if (parent.GetComponent<Rigidbody2D>().velocity.magnitude == 0)
            Debug.Log("bullet falloff velocity bug");

        if (parent.GetComponent<Rigidbody2D>().velocity.magnitude <= fallOffVel && cheap == 10)
        {
            if (parent.GetComponent<Rigidbody2D>().velocity.magnitude < 0.01f)
                Destroy(gameObject.transform.parent.gameObject);

            Color color = parent.GetComponent<SpriteRenderer>().material.color;
            color.a = map(parent.GetComponent<Rigidbody2D>().velocity.magnitude, 0.01f, fallOffVel, 0, 1);
            parent.GetComponent<SpriteRenderer>().material.color = color;
            
        }

        if (cheap < 10)
            cheap++;
    }

    private float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

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
