using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private healthControl plyHPScript;

    [SerializeField] private float regSpeed = 500f;
    private float speed;
    [SerializeField] private GameObject setDroppedItemFab;
    [HideInInspector] private Rigidbody2D rb;
    [HideInInspector] private Vector2 movement;

    [SerializeField] private AudioSource a;
    [SerializeField] private AudioClip[] sounds;
    private int ct = 0;

    private float timer = 0.0f;

    [HideInInspector] public GameObject itemObj;

    // get the canvas object that shows the "press f to pick up" message
    private GameObject dialogue;

    public float getSpeed()
    {
        return regSpeed;
    }

    public void setSpeed(float sped)
    {
        speed = sped;
    }

    // Start is called before the first frame update
    void Start()
    {
        // get dialgoue component from helper script
        dialogue = GameObject.Find("DialogueHolder").GetComponent<DialogueHolder>().PickUp;

        // get the rigid body componenet so i dont have to add it in the inspector
        rb = this.GetComponent<Rigidbody2D>();
        // audio
        a = GetComponent<AudioSource>();

        speed = regSpeed;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (plyHPScript.getLife()) // only move if alive
        {
            // movement
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                // delay foot step sounds so it sounds like footsteps based off the player's speed
                if (timer >= 0)
                {
                    a.PlayOneShot(sounds[ct]);

                    ct++;
                    if (ct >= 2) ct = 0;

                    timer = timer - ((1000 - speed) / 900);
                }
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
            }



            // get the vector movement dependent on user input
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetKeyDown(KeyCode.Q)) //  q to drop an object
            {
                // is player holding weapon in first place
                bool holdingWeapon = false;
                int i = 0;
                for (; i < this.transform.GetChild(0).childCount; i++)
                {
                    Debug.Log(this.transform.GetChild(0).childCount);
                    if (this.transform.GetChild(0).GetChild(i).gameObject.tag == "weapon")
                    {
                        Debug.Log("Found a weapon");
                        holdingWeapon = true;
                        break;
                    }
                }
                // if so do the stuff to make it drop
                if (holdingWeapon)
                {
                    this.transform.GetChild(0).GetChild(i).gameObject.GetComponent<gunControl>().eraseRecoil();
                    speed = regSpeed;

                    a.PlayOneShot(sounds[2]);

                    GameObject.Find("Inventory").GetComponent<inventoryControl>().setActive("empty"); // first set inventory to empty

                    GameObject tmp = Instantiate(setDroppedItemFab, new Vector3(0, 0, 3), transform.rotation); // then create the item to drop it using item prefab variant

                    GameObject dropped = this.transform.GetChild(0).GetChild(i).gameObject;
                    Transform droppedTrans = this.transform.GetChild(0).GetChild(i);

                    droppedTrans.Find("WorldImage").gameObject.SetActive(true);

                    tmp.GetComponent<PickUppableSet>().setWhatIAm(dropped); // set the item type to what was dropped

                    droppedTrans.SetParent(GameObject.Find("DroppedGuns").transform);

                    dropped.SetActive(false);

                    tmp.transform.SetParent(gameObject.transform, false); // parent the drop to the player so it drops under the player

                    tmp.transform.parent = null; // unparent it so it doesnt follow the player anymore
                }
            }
        }
        else
        {
            // disable player from moving at all if it is dead
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
        }
    }
  
    private void FixedUpdate()
    {
        // move rigid body instead of actual player so you have smooth looking collisions
        rb.AddForce(movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if that object is player
        if (other.tag == "items")
        {
            // j debug
            Debug.Log("Press F to pick up");
            // get the dialogue thingy, make sure it isnt null so no error, then make it show
            if (dialogue != null) dialogue.SetActive(true);
            itemObj = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // check if that object is player
        if (other.tag == "items")
        {
            Debug.Log("Can't anymore");
            // hide the dialgoue
            if (dialogue != null) dialogue.SetActive(false);
            // update the is touching property
            itemObj = null;
        }
    }
}
