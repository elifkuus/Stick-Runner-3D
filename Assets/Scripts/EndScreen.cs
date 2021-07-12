using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject endScrn;
    PlayerManager pm;
    //public int nLevel=0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            endScrn.gameObject.SetActive(true);
            //nLevel += 1;
           // pm.LoadNextLevel(nLevel);
            
        }
    }

    private void Start()
    {
        pm = FindObjectOfType<PlayerManager>();
    }
}
