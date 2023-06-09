using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScopeScale : MonoBehaviour
{
    [HideInInspector] private float goalScope = 7f;
    [SerializeField] private CinemachineVirtualCamera vcam;

    void Start()
    {
        vcam.m_Lens.OrthographicSize = 7;
    }
    void Update()
    {
        // this is just here so we can test scope changing with user input; actual game will probably have an item pick up that triggers this
        if (Input.GetKeyDown(KeyCode.N))
        {
            goalScope -= 2;
            Debug.Log(goalScope);
        }
        if (Input.GetKeyDown(KeyCode.M)) {
            goalScope += 2;
            Debug.Log(goalScope);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            goalScope += 15;
            Debug.Log(goalScope);
        }

        vcam.m_Lens.OrthographicSize += ((goalScope - vcam.m_Lens.OrthographicSize) / 50f); // smooth scaling
    }
}
