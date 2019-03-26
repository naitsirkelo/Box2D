using UnityEngine;

public class CoinCollision : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player")) {
            this.gameObject.SetActive(false);

            Debug.Log("Coin collision");
        }
    }

}
