using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [SerializeField] private GameObject itemFab;
    [SerializeField] private GameObject treeFab;
    [SerializeField] private GameObject rockFab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
            item();
        for (int i= 0; i < 25; i++)
            tree();
        for (int i = 0; i < 25; i++)
            rock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void item() // add paramter for what item is in the object (later)
    {
        Instantiate(itemFab, new Vector3(Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f), 1), transform.rotation);
    }
    void tree() // add paramter for what item is in the object (later)
    {
        Quaternion tempRandAngle = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
        Instantiate(treeFab, new Vector3(Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f), -1), tempRandAngle);
    }
    void rock() // add paramter for what item is in the object (later)
    {
        Quaternion tempRandAngle = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
        Instantiate(rockFab, new Vector3(Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f), 0), tempRandAngle);
    }
}
