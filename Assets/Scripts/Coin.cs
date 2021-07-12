using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //coin'i y ekseninde donduruyoruz.
        transform.Rotate(50*Time.deltaTime,0,0);
    }

    //oyuncu coine degdiginde(trigger ile kontrol ediyoruz) coin artacak ve yok olacak
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            PlayerManager.numberOfCoins += 1;
            Destroy(gameObject);
        }
    }
}
