using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUppableSet : MonoBehaviour
{
    // boolean to detect if touching player
    private bool touching = false;
    // boolean to ensure the thingy in the update loop only runs once
    // private bool ranAlready = false;
    private GameObject whatIAm;

    [SerializeField] private float scale = 1.3f;

    public GameObject ammoRing; 
    //runs once at start
    void Start()
    {

    }

    public void setWhatIAm(GameObject wia)
    {
        gameObject.transform.localScale = new Vector3(0,0,0);

        whatIAm = wia;
        if (whatIAm.transform.Find("WorldImage") != null)
        {
            GameObject temp = Instantiate(whatIAm.transform.Find("WorldImage").gameObject, new Vector3(0, 0, 2), transform.rotation);
            temp.transform.SetParent(gameObject.transform, false);
            temp.transform.localPosition = new Vector3(temp.transform.localPosition.x, temp.transform.localPosition.y, -1);
            if (whatIAm.GetComponent<gunControl>().getAmmoType() == "9mm")
            {
                GameObject ammoRingTemp = Instantiate(ammoRing, new Vector3(0,0,0.5f), transform.rotation);
                ammoRingTemp.transform.SetParent(gameObject.transform, false);
                Color yellow = new Color(0.9490197f, 0.6470588f, 0.003921569f, 1f);
                ammoRingTemp.GetComponent<Renderer>().material.color = yellow;
            }
            if (whatIAm.GetComponent<gunControl>().getAmmoType() == "7.62mm")
            {
                GameObject ammoRingTemp = Instantiate(ammoRing, new Vector3(0,0,0.5f), transform.rotation);
                ammoRingTemp.transform.SetParent(gameObject.transform, false);
                Color blue = new Color(0.003921569f, 0.3803922f, 0.9529412f, 1f);
                ammoRingTemp.GetComponent<Renderer>().material.color = blue;
            }
            if (whatIAm.GetComponent<gunControl>().getAmmoType() == "5.56mm")
            {
                GameObject ammoRingTemp = Instantiate(ammoRing, new Vector3(0,0,0.5f), transform.rotation);
                ammoRingTemp.transform.SetParent(gameObject.transform, false);
                Color green = new Color(0.01176471f, 0.5882353f, 0f, 1f);
                ammoRingTemp.GetComponent<Renderer>().material.color = green;
            }
            if (whatIAm.GetComponent<gunControl>().getAmmoType() == ".308 Subsonic")
            {
                GameObject ammoRingTemp = Instantiate(ammoRing, new Vector3(0,0,0.5f), transform.rotation);
                ammoRingTemp.transform.SetParent(gameObject.transform, false);
                Color blackishThing = new Color(0.1931904f, 0.1981132f, 0.1429779f, 1f);
                ammoRingTemp.GetComponent<Renderer>().material.color = blackishThing;
            }
        }
        if (whatIAm.tag == "ammo")
        {
            GameObject Ammotemp = Instantiate(whatIAm, new Vector3(0, 0, 0.5f), transform.rotation);
            Ammotemp.transform.localPosition = new Vector3(whatIAm.transform.localPosition.x - 1, whatIAm.transform.localPosition.y, -1); //Left one 
           
            GameObject Ammotemp2 = Instantiate(whatIAm, new Vector3(0, 0, 0.5f), transform.rotation);
            Ammotemp2.transform.localPosition = new Vector3(whatIAm.transform.localPosition.x + 1, whatIAm.transform.localPosition.y, -1); //right one 
        }
    }

    // runs every frame
    void Update()
    {
        gameObject.transform.localScale += ((new Vector3(scale, scale, 0) - gameObject.transform.localScale) / 10f);

        // this only runs once becuase of the boolean
        // if (!ranAlready)
        // {
        // makes the dialogue hidden at start; done here becuase for some reason it was setting the object to null when doing it at start; probably some initialization problem
        // dialogue.SetActive(false);
        // make it only run once
        // ranAlready = true;
        // }
        // check if touching the player
        if (touching)
        {
            // check if F is pressed when touching player
            if (Input.GetKeyDown(KeyCode.F) && GameObject.Find("PlayerHitBox").GetComponent<PlayerControl>().itemObj == gameObject && GameObject.Find("Inventory").GetComponent<inventoryControl>().getActive() == "empty")
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
                    temp.transform.Find("WorldImage").gameObject.SetActive(false);
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
            
            touching = false;
        }
    }
}
