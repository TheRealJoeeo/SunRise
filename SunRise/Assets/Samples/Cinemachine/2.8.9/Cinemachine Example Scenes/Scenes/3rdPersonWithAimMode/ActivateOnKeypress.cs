using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ammoTypeControl : MonoBehaviour
{
    [SerializeField] private string ammoType; 
    // Start is called before the first frame update
    
    public string getAmmoType()
    {
        return ammoType; 
    }

    public void setAmmoType(string ammoType)
    {
        this.ammoType = ammoType; 
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
