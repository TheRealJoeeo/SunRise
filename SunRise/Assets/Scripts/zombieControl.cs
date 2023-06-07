using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieControl : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private ParticleSystem ZombieParticles;
    ParticleSystem.Particle[] Particles;

    [SerializeField] private float health = 20f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        ZombieParticles = this.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        ZombieParticles.Stop();

        if (Particles == null || Particles.Length < ZombieParticles.main.maxParticles)
            Particles = new ParticleSystem.Particle[ZombieParticles.main.maxParticles];
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

    public void appDmg(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            // ZombieParticles.Emit(10);

            // int numParticlesAlive = ZombieParticles.GetParticles(Particles);
            // while (numParticlesAlive > 0) 
            // {
            //     Debug.Log(numParticlesAlive);
            //     numParticlesAlive = ZombieParticles.GetParticles(Particles);
            // }
            
            Destroy(gameObject);
        }
    }
}
