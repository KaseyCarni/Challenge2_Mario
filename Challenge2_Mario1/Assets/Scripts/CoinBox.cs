using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour {

    public GameObject coinBox;

    public GameObject coinSpawnPoint;

    public Object coinPrefabs;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Vector3 coinHeight = this.transform.position - collider.gameObject.transform.position;

        float coinDistance = coinHeight.magnitude;

        Vector3 direction = coinHeight / coinDistance;

        if ((direction.x < 0.1 && direction.x > -1.1) && (direction.y < 1.1 && direction.y > 0.4) && collider.tag == "player")
        {
            CoinJump();
        }
    }
    void CoinJump()
    {
        coinBox.SetActive(true);

        this.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        this.SpawnCoin();
    }
    void SpawnCoin()
    {
        int random = Random.Range(0, coinPrefabs.Length);
        GameObject coin = Object.Instantiate(coinPrefabs[(Random.Range(0, coinPrefabs.Length))], coinSpawnPoint.transform.position, coinSpawnPoint.transform.rotation) as GameObject;
        coin.GetComponent<Rigidbody2D>().AddForce(new Vector2((Random.Range(-120, 120)), 700));
    }
}
