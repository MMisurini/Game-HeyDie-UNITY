using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WincegroundCollider : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps = null;

    List<ParticleSystem.Particle> enterList = new List<ParticleSystem.Particle>();

    void OnEnable() {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnTriggerStay(Collider other) {
        if (ps.time > 0.1f && ps.time < 0.80f) {
            var trigger = ps.trigger.GetCollider(0);
            trigger.GetComponent<StateController>().Die();
        }   
    }
}
