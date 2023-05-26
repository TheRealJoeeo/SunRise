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
        for (int i= 0; i < 25; i++)
            tree();
        for (int i = 0; i < 25; i++)
            rock();
        for (int i = 0; i < 25; i++)
            crate();
        for (int i = 0; i < 3; i++)
            item();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void item()
    {
        GameObject temp = Instantiate(itemFab, new Vector3(Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f), 1), transform.rotation);
    }
    void tree() 
    {
        Quaternion tempRandAngle = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
        Instantiate(treeFab, new Vector3(Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f), -1), tempRandAngle);
    }
    void rock() 
    {
        Quaternion tempRandAngle = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
        Instantiate(rockFab, new Vector3(Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f), 0), tempRandAngle);
    }
    void crate()
    {
        Instantiate(crateFab, new Vector3(Random.Range(-22.5f, 22.5f), Random.Range(-22.5f, 22.5f), 1), transform.rotation);
    }
}
