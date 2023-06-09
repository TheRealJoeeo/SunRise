using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [SerializeField] private GameObject itemFab;
    [SerializeField] private GameObject treeFab;
    [SerializeField] private GameObject rockFab;
    [SerializeField] private GameObject crateFab;
    [SerializeField] private GameObject zombieFab;

    [SerializeField] private float delayBetweenWaves;
    private float timer;

    [SerializeField] private healthControl plyHPScript;

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

        // spawn a set beginning wave
        for (int i = 0; i < 5; i++)
            spawn(zombieFab, 7f, 7f, 0, true, 1000);

        timer = 0;
        timer = timer - delayBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (plyHPScript.getLife())
        {
            if (timer >= 0)
            {
                Debug.Log("New Wave");
                for (int i = 0; i < Random.Range(15, 20); i++)
                {
                    spawn(zombieFab, -22f, 22f, 0, true, 1000);
                }
                timer = timer - delayBetweenWaves;
            }
            timer += Time.deltaTime;
        }
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
