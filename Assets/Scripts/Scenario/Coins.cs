using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private float coinsValue = 10f;
    [Header("Som ao pegar a moeda")]
    [SerializeField] private AudioSource coinsSounds = null;

    void OnEnable() {
        coinsSounds = GameObject.FindGameObjectWithTag("Audio").transform.GetChild(0).GetComponent<AudioSource>();    
    }

    void FixedUpdate() {
        transform.Rotate(Vector3.up * 150 * Time.deltaTime);

        Destroy(transform.gameObject, 5f);
    }

    public float CoinsValue {
        get { return coinsValue; }
        set { coinsValue = value; }
    }

    public Vector3 Spawn() {
        return new Vector3(Random.Range(-4.5f, 4.5f), transform.position.y, -4.5f);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GameObject.FindGameObjectWithTag("Controller").transform.GetChild(0).GetComponent<EMController>().MoneyInGame += coinsValue;
            coinsSounds.Play();

            Destroy(transform.gameObject);
        }
    }

}
