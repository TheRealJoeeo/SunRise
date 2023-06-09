using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithDropControl : MonoBehaviour
{
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float initialScale = 0.6f;

    [Tooltip("Parent object of the sprite objects that show when the thing (ie a tree) is not destroyed")]
    [SerializeField] private GameObject notResidue;

    [Tooltip("Particle System for when hit or destroyed (not required)")]
    [SerializeField] private ParticleSystem breakEffect;
    private float health;

    [SerializeField] private GameObject itemFab;

    private Collider2D c;

    private bool destroyed = false;

    private AudioSource a;
    [SerializeField] private AudioClip[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        if (breakEffect != null) breakEffect.Stop();
        transform.localScale = new Vector3(initialScale, initialScale, 0);
        health = initialHealth;

        c = GetComponent<Collider2D>();
        c.enabled = true;

        a = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (!destroyed)
            {
                if (breakEffect != null) breakEffect.Emit(Random.Range(7, 14));
                a.PlayOneShot(sounds[0]);

                GameObject temp = Instantiate(itemFab, gameObject.transform.position, transform.rotation);

                c.enabled = false;
                Destroy(notResidue);

                destroyed = true;
            }
        }
    }

    public void appDmg(float dmg) // apply damage function
    {
        a.PlayOneShot(sounds[1]);
        if (breakEffect != null) breakEffect.Emit(Random.Range(0, 2));
        health -= dmg;
        if (health < 0) health = 0;
        transform.localScale = new Vector3(map(health, 0, initialHealth, (initialScale / 2f), initialScale), map(health, 0, initialHealth, (initialScale / 2f), initialScale), 0);
    }

    private float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
