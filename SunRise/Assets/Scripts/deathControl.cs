using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class deathControl : MonoBehaviour
{
    [SerializeField] private healthControl plyHPScript;
    [SerializeField] private GameObject msgObj;

    private float score = 0;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        msgObj.GetComponent<CanvasGroup>().alpha = 0; // set death message overlay to transparent
    }

    // Update is called once per frame
    void Update()
    {
        if(!(plyHPScript.getLife())) //  if dead....
        {
            if (timer < 1.5) // wait for 1.5 seconds
                timer += Time.deltaTime;
            else
            {
                // then set the death message to active and slowly fade it in
                msgObj.SetActive(true);
                msgObj.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = score.ToString();
                msgObj.GetComponent<CanvasGroup>().alpha += ((1 - msgObj.GetComponent<CanvasGroup>().alpha) / 100f);
            }
        }
        else
        {
            // set death overlay to false to stop from accidental wierd collisions and stuff (just making it transparent doesnt get rid of it)
            msgObj.SetActive(false);
        }
    }

    public void increaseScoreBy(float sc)
    {
        // controls player's score
        score += sc;
    }
}
