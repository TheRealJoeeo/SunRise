using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [SerializeField] private GameObject itemFab;
    [SerializeField] private GameObject treeFab;
    [SerializeField] private GameObject rockFab;
    [SerializeField] private GameObject crateFab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 25; i++)
            spawn(treeFab, -22.5f, 22.5f, -1, true, 1000);
        for (int i = 0; i < 25; i++)
            spawn(rockFab, -22.5f, 22.5f, 0, true, 1000);
        for (int i = 0; i < 25; i++)
            spawn(crateFab, -22.5f, 22.5f, 1, false, 1000);
        for (int i = 0; i < 3; i++)
            spawn(itemFab, -22.5f, 22.5f, 1, false, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawn(GameObject obj, float start, float end, float layer, bool randAngle, float tries)
    {
        Quaternion tempRandAngle;
        if (randAngle) tempRandAngle = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
        else tempRandAngle = transform.rotation;

        GameObject temp = Instantiate(obj, new Vector3(Random.Range(start, end), Random.Range(start, end), layer), tempRandAngle);

        Physics2D.SyncTransforms();
        Debug.Log(temp.GetComponent<Rigidbody2D>().IsTouchingLayers());
        Physics2D.SyncTransforms();

        if (temp.GetComponent<Collider2D>().IsTouchingLayers())
        {
            Debug.Log("ReAdjusting");
            if (tries <= 0) // prevent stack overflow
            {
                Debug.Log("Failed to find a clear space in the tries given");
                return;
            }
            else
            {
                spawn(obj, start, end, layer, randAngle, tries--);
            }
        }
    }
}
