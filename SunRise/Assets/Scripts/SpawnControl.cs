using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public GameObject itemFab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
            item();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void item() // add paramter for what item is in the object (later)
    {
        Instantiate(itemFab, new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), 0), transform.rotation);
    }
}
