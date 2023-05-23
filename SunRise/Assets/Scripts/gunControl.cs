using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControl : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private float dmg;
    [SerializeField] private float recoil;
    [SerializeField] private float bulletVel;
    [SerializeField] private float accuracy;

    [SerializeField] private GameObject bullet;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject temp = Instantiate(whatIAm, new Vector3(0, 1, 0), transform.rotation);
            temp.transform.SetParent(GameObject.Find("PlayerGraphicsAndFistHitbox").transform, false);
            
        }   
    }
}
