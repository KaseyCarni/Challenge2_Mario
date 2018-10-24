using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour {

    public GameObject poppedStatePrefab;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Vector3 heading = this.transform.position - collider.gameObject.transform.position;

        float distance = heading.magnitude;

        Vector3 direction = heading / distance;

        if ((direction.x < 0.1 && direction.x > -1.1) && (direction.y < 1.1 && direction.y > 0.4) && collider.tag == "player")
        {
            CoinPop();
        }
    }

 
     //I tride two types to get this to work

    void CoinPop()
    {
        poppedStatePrefab.SetActive(true);
        this.gameObject.SetActive(false);
    }
   
}