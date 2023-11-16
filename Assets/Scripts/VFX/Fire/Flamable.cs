using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamable : MonoBehaviour {

	[SerializeField] private ParticleSystem flamePS;

    private void OnParticleCollision(GameObject other) {
        if (other.CompareTag("Fireball") && !flamePS.isEmitting)
        {
            flamePS.Play();
        }
    }

}
