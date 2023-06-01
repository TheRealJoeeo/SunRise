using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthControl : MonoBehaviour
{
    [SerializeField] private float playerHp = 100f;
    private Slider hpbar;

    // Start is called before the first frame update
    void Start()
    {
        hpbar = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = playerHp;
    }
}
