using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireType // this is so the fire type appears as a drop down in the inspector window
{
    SemiRapid,
    Rapid,
    Burst
};

public class gunControl : MonoBehaviour
{
    [SerializeField] private string itemType;
    [SerializeField] private float bulletVel;
    [SerializeField] private float bulletFallOffVel;
    [SerializeField] private float bulletDmg;
    [SerializeField] private float spreadAngle;

    [SerializeField] private float fireDelayInSecondsIThink;
    [SerializeField] private float recoil;
    private bool isRecoiled = false;
    private PlayerControl spedScript;

    [SerializeField] private FireType FireRateType = new FireType();
    [SerializeField] private ParticleSystem shellEjection;

    [SerializeField] private float xOffSet;
    [SerializeField] private float yOffSet;

    [SerializeField] private GameObject bullet;

    private AudioSource a;
    [SerializeField] private AudioClip[] sounds;

    private Rigidbody2D rb;
    private bulletControl bulletScript;

    private float timer = 0.0f;

    [SerializeField] private string ammoType; 

    public void eraseRecoil()
    {
        isRecoiled = false;
    }

    public string getAmmoType()
    {
        return ammoType; 
    }

    // Start is called before the first frame update
    void Start()
    {
        if (shellEjection != null) shellEjection.Stop(); // set ejection
        this.transform.localPosition = new Vector2(xOffSet, yOffSet);
        GameObject.Find("Inventory").GetComponent<inventoryControl>().setActive(itemType); // update the inventory so that the player knows its holding a gun

        // get other necssary components
        a = GetComponent<AudioSource>();

        a.PlayOneShot(sounds[1]);

        spedScript = GameObject.Find("PlayerHitBox").GetComponent<PlayerControl>();

        isRecoiled = false; // not slowed down when first initalized
    }

    // Update is called once per frame
    void Update()
    {
        // differnt types of firing
        if (
        (FireRateType == FireType.SemiRapid && Input.GetMouseButtonDown(0)) ||
        (FireRateType == FireType.Rapid && Input.GetMouseButton(0))
        )
        {
            if (timer >= 0)
            {

                a.PlayOneShot(sounds[0]); // plays sound

                GameObject temp = Instantiate(bullet, gameObject.transform.Find("bulletSpawnLocation").transform.localPosition, transform.rotation); // creates bullet off of bullet prefab
                temp.transform.SetParent(GameObject.Find("bulletSpawnLocation").transform, false); // sets the bullet to a child of the player to get its rotation

                bulletScript = temp.transform.GetChild(0).GetComponent<bulletControl>(); // get the child of the bullet, which has the script that has the function to change damage

                if (bulletScript != null) bulletScript.setDamage(bulletDmg); // sets the damage of the bullet by calling the set damage function in the bulletControl script
                else Debug.Log("Oh no");

                if (bulletScript != null) bulletScript.setFallOff(bulletFallOffVel); // sets the velocity fall off of the bullet (when it slows down enough it dies)
                else Debug.Log("Oh no");

                rb = temp.GetComponent<Rigidbody2D>(); // gets the rigidbody of the bullet

                rb.SetRotation(rb.rotation + Random.Range(-spreadAngle, spreadAngle));

                rb.AddRelativeForce(new Vector2(0, bulletVel)); // move the rigidbody by the velocity set by the user

                temp.transform.parent = null; // remove the bullet as a child of the player so its detached from it (ie so it doesnt rotate with it anymore)

                timer = 0;
                timer = timer - fireDelayInSecondsIThink; // reset timer (this stuff adds the fire delay (based on seconds, not frames))

                if (shellEjection != null) shellEjection.Emit(1); // emit bullet shell

                isRecoiled = true; // apply recoil, if any
            }
        }
        timer += Time.deltaTime; // increase timer

        if (timer >= 0)
            isRecoiled = false;

        // slow player if recoiled
        if (isRecoiled)
        {
            spedScript.setSpeed(spedScript.getSpeed() - recoil);
        }
        else
        {
            spedScript.setSpeed(spedScript.getSpeed());
        }
    }
}