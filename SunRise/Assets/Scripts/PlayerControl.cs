using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject setDroppedItemFab;
    [HideInInspector] private Rigidbody2D rb;
    [HideInInspector] private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        // get the rigid body componenet so i dont have to add it in the inspector
        rb = this.GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update()
    {
        // get the vector movement dependent on user input
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Q)) //  q to drop an object
        {
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
            if (holdingWeapon)
            {
                GameObject.Find("Inventory").GetComponent<inventoryControl>().setActive("empty"); // first set inventory to empty

                GameObject tmp = Instantiate(setDroppedItemFab, new Vector3(0,0,3), transform.rotation); // then create the item to drop it using item prefab variant

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
  
    private void FixedUpdate()
    {
        // move rigid body instead of actual player so you have smooth looking collisions
        rb.AddForce(movement * speed * Time.fixedDeltaTime);
    }
}
