using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs; //kac tane tile eklenecek
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;

    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;

    public int i = 1;
    void Start()
    {
        
        SpawnTile(0);
        
    }


    void Update()
    {
        SpawnTile(i);
        if (i == 5)
        {
            Debug.Log("Oyun bitti");
           
            
        }
        
       
        
      /*  if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            DeleteTile();
        }*/
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength; 
        i++;
    }

   /* private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }*/
}