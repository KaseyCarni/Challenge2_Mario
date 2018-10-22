using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnC : MonoBehaviour {


    public GameObject spawnPoint;

    public Object coins;

    void OnTriggerEnter2D(Collider2D other)
    {
        this.CoinSpawn();
    }
    void CoinSpawn()
    {
        int random = Random.Range(0, coins.Length);
        GameObject coin = Object.Instantiate(coins[(Random.Range(0, coins.Length))], spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        coin.GetComponent<Rigidbody2D>().AddForce(new Vector2((Random.Range(-120, 120)), 700));
    }
}

