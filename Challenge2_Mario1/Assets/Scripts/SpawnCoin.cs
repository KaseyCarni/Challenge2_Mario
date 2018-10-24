using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour {

    public GameObject coinSpawnPoint;

    public Object[] coinPrefabs;



    void Start()
    {
        this.spawnTheCoin();
      
    }

   void spawnTheCoin()
    {
        int random = Random.Range(0, coinPrefabs.Length);
        GameObject coin = Object.Instantiate
          (coinPrefabs[(Random.Range(0, coinPrefabs.Length))],
           coinSpawnPoint.transform.position,
           coinSpawnPoint.transform.rotation) as GameObject;

        coin.GetComponent<Rigidbody2D>().AddForce(new Vector2((Random.Range(-120, 120)), 700));
    }
   // It spawns one Coin on start i can not get it to load more
}