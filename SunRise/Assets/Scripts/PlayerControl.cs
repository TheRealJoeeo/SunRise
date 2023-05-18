using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
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
    }
  
    private void FixedUpdate()
    {
        // move rigid body instead of actual player so you have smooth looking collisions
        rb.AddForce(movement * speed * Time.fixedDeltaTime);
    }
}
