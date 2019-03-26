using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {

        Physics2D.IgnoreLayerCollision(8, 10);

    }

    // void OnTriggerEnter2D(Collider2D col) {
    //
    //     if (col.gameObject.tag == "Coin") {
    //
    //         col.gameObject.SetActive(false);
    //     }
    // }

}
