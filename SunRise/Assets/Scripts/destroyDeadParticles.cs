using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDeadParticles : MonoBehaviour
{
    // script to destroy particle systems after their particles have all died
    // this for when a particle system's partent needs to be destroyed, but it still has to finish emitting its particles

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < this.transform.childCount; i++) {
            if (!this.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>().IsAlive()) // check if anymore particles are alive
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }
        }
    }
}
