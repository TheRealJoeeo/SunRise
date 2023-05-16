using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    //First, it's necessary that we refrence other parts of the game object like the rigid body 2D, since it only auto-recognizes Transform

    public Rigidbody2D myRigidbody; // Like declaring a instance variable in java, with the Unity editor we can make this equal to something easily
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive) 
        {
            myRigidbody.velocity = Vector2.up * flapStrength; //Vector used to move the object, Vector2 is a method that easily does a vector of (0,1), and when multiplied it is a good choice
        }

        if (transform.position.y > 18 || transform.position.y < -16)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false; 
    }

    public bool getBirdStatus()
    {
        return birdIsAlive; 
    }

}
