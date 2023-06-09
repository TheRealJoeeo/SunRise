using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDeadParticles : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < this.transform.childCount; i++) {
            if (!this.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>().IsAlive())
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }
        }
    }
}
