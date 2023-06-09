using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthControl : MonoBehaviour
{
    [SerializeField] private float playerHp = 100f;
    private Slider hpbar;
    private bool life = true;
    [SerializeField] private GameObject dicon;
    [SerializeField] private GameObject playerGraphics;

    public bool getLife()
    {
        return life;
    }

    // Start is called before the first frame update
    void Start()
    {
        hpbar = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = playerHp;
        /* debug controls
        if (Input.GetKeyDown(KeyCode.K)) {
            applDmg(10);
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            applDmg(-10);
        }
        */

        if (playerHp <= 0) { 
            // if health less than zero, then die
            life = false;
            // change player from looking like a player to just a skull icon
            dicon.SetActive(true); 
            Destroy(playerGraphics);    
        }

        else life = true;

  }

    public void applDmg(float dmg) { // Make it negative to give health 
        // sound affects and particles maybe later
        //a.PlayOneShot(sounds[1]);
        //if (breakEffect != null) breakEffect.Emit(Random.Range(0,2));

        // apply damage, make sure it no go below zero
        playerHp -= dmg;
        if (playerHp < 0) playerHp = 0;
    }
    
}
