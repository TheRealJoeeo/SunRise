using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieControl : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float health = 20f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
            Vector3 ObjPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Camera.main.WorldToScreenPoint(player.transform.position) - ObjPos;
            float z = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, -z);

            rb.AddForce(transform.up);
    }
}
