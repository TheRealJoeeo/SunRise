using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    // helper class to get the dialogues that appear on canvas - since sometimes they are set to inactive, we cannot just use .find to find them with newly instantiated prefabs
    public GameObject PickUp; 
}
