using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieControl : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private ParticleSystem ZombieParticles;

    [SerializeField] private float health = 20f;

    [SerializeField] private float speed = 3f;

    [SerializeField] private float attackDelay = 20f;
    private float counter;

    private Vector2 localLocalR;
    private Vector2 localLocalL;
    [SerializeField] private GameObject Rfist;
    [SerializeField] private GameObject Lfist;

    [SerializeField] private AudioSource a;
    [SerializeField] private AudioClip[] sounds;
    private float timer = 0.0f;

    private bool isTouchingPlayer;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerHitBox");

        rb = this.GetComponent<Rigidbody2D>();
        ZombieParticles.Stop();

        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // MOVEMENT CONTROL //

        Vector3 ObjPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Camera.main.WorldToScreenPoint(player.transform.position) - ObjPos;
        float z = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -z);

        rb.AddForce(transform.up * speed);

        // FIST CONTROL //

        // right
        localLocalR *= 0.9f;
        Rfist.transform.localPosition = new Vector2((localLocalR.x + 0.4f), (localLocalR.y + 0.4f));
        // left
        localLocalL *= 0.9f;
        Lfist.transform.localPosition = new Vector2((localLocalL.x - 0.4f), (localLocalL.y + 0.4f));

        if (isTouchingPlayer && counter == 0)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;

            int temp = Random.Range(0, 2);

            if (temp == 0)
                localLocalR = new Vector2(-0.45f, 0.7f);
            else
                localLocalL = new Vector2(0.45f, 0.5f);

            GameObject.Find("Slider").GetComponent<healthControl>().applDmg(5f);
            a.PlayOneShot(sounds[1]);
        }

        if (timer >= 0)
        {
            a.PlayOneShot(sounds[0]);

            timer = timer - (Random.Range(4f, 7f));
        }
        timer += Time.deltaTime;

        counter++;
        if (counter > attackDelay)
            counter = 0;
    }

    public void appDmg(float dmg)
    {
        health -= dmg;
        ZombieParticles.Emit(1);
        if (health <= 0)
        {
            ZombieParticles.Emit(10);
            ZombieParticles.gameObject.transform.SetParent(GameObject.Find("ParticleDestroyer").transform, true);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouchingPlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouchingPlayer = false;
        }
    }
}
