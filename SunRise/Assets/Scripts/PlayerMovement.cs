using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;

        x *= Time.deltaTime;
        y *= Time.deltaTime;

        transform.Translate(x, y, 0);
    }
}
