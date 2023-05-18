using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public GameObject itemFab;
    public GameObject treeFab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
            item();
        for (int i= 0; i < 100; i++)
            tree();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void item() // add paramter for what item is in the object (later)
    {
        Instantiate(itemFab, new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), 0), transform.rotation);
    }
    void tree() // add paramter for what item is in the object (later)
    {
        Instantiate(treeFab, new Vector3(Random.Range(-18, 18), Random.Range(-18, 18), 0), transform.rotation);
    }
}
