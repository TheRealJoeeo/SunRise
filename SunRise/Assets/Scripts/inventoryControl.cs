using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryControl : MonoBehaviour
{
    private string activeSlot; // stores the type of whats in the player's "hands" currently
    // ie just the hands, or like the type of gun such as a pistol or rifle

    void Start()
    {
        activeSlot = "empty";
    }

    public string getActive()
    {
        return activeSlot;
    }

    public void setActive(string slot)
    {
        activeSlot = slot;
    }
}
