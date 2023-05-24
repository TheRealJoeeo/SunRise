using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControl : MonoBehaviour
{
    [SerializeField] private string itemType;
    [SerializeField] private float bulletVel;
    [SerializeField] private float bulletFallOffVel;
    [SerializeField] private float bulletDmg;
    [SerializeField] private float firingTypeNotInUseYet;

    [SerializeField] private float xOffSet;
    [SerializeField] private float yOffSet;

    [SerializeField] private GameObject bullet;

    private Rigidbody2D rb;
    private bulletControl bulletScript;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector2(xOffSet, yOffSet);
        GameObject.Find("Inventory").GetComponent<inventoryControl>().setActive(itemType);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject temp = Instantiate(bullet, gameObject.transform.Find("bulletSpawnLocation").transform.localPosition, transform.rotation); // creates bullet off of bullet prefab
            temp.transform.SetParent(GameObject.Find("PlayerGraphicsAndFistHitbox").transform, false); // sets the bullet to a child of the player to get its rotation
            bulletScript = temp.transform.GetChild(0).GetComponent<bulletControl>(); // get the child of the bullet, which has the script that has the function to change damage
            
            if (bulletScript != null) bulletScript.setDamage(bulletDmg); // sets the damage of the bullet by calling the set damage function in the bulletControl script
            else Debug.Log("Oh no");

            if (bulletScript != null) bulletScript.setFallOff(bulletFallOffVel); // sets the velocity fall off of the bullet (when it slows down enough it dies)
            else Debug.Log("Oh no");

            rb = temp.GetComponent<Rigidbody2D>(); // gets the rigidbody of the bullet
            rb.AddRelativeForce(new Vector2(0, bulletVel)); // move the rigidbody by the velocity set by the user
            temp.transform.parent = null; // remove the bullet as a child of the player so its detached from it (ie so it doesnt rotate with it anymore)
        }   
    }
}
