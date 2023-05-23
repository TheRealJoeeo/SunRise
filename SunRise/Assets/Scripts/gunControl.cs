using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControl : MonoBehaviour
{
    // to implement bullet damage later
    [SerializeField] private float bulletVel;

    [SerializeField] private GameObject bullet;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject temp = Instantiate(bullet, new Vector3(0, 1, 0), transform.rotation);
            temp.transform.SetParent(GameObject.Find("PlayerGraphicsAndFistHitbox").transform, false);
            rb = temp.GetComponent<Rigidbody2D>();
            rb.AddRelativeForce(new Vector2(0, bulletVel));
            temp.transform.parent = null;
        }   
    }
}
