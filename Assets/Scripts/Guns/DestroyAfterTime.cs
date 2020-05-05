using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    private bool start = false;

    private void OnEnable() {
        start = true;
    }

    void Update() {
        if(start)
        Destroy(transform.gameObject, transform.GetComponent<ParticleSystem>().main.duration);
    }
}
