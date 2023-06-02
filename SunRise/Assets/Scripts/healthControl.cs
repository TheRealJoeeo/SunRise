using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthControl : MonoBehaviour
{
    [SerializeField] private float playerHp = 100f;
    private Slider hpbar;
    private bool life;
    [SerializeField] private GameObject dicon;

    // Start is called before the first frame update
    void Start()
    {
        hpbar = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = playerHp;
        if (Input.GetKeyDown(KeyCode.K)) {
            applDmg(10);
        }
        if (playerHp <= 0) {
            life = false;
            dicon.SetActive(true);
        }
        else life = true;

  }

    public void applDmg(float dmg) {
        //a.PlayOneShot(sounds[1]);
        //if (breakEffect != null) breakEffect.Emit(Random.Range(0,2));
        playerHp -= dmg;
        if (playerHp < 0) playerHp = 0;
    }
    
}
