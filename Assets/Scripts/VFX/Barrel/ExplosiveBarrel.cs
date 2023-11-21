using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour {

    [field: SerializeField] private float delay = 3f;
    [field: SerializeField] private ParticleSystem explosionPS;
    [field: SerializeField] private GameObject fracturedBarrel;

    [field: SerializeField] private float explosionForce = 200f;
    [field: SerializeField] private float explosionRadius = 2f;
    [field: SerializeField] private float upwardsModifier = 0f;

    private Rigidbody[] parts;

    void Start() {
        parts = fracturedBarrel.GetComponentsInChildren<Rigidbody>();
        StartCoroutine(ExplodeCo());
    }

    IEnumerator ExplodeCo() {
        yield return new WaitForSeconds(delay);
        explosionPS.Play();

        gameObject.SetActive(false);
        fracturedBarrel.SetActive(true);

        foreach (Rigidbody part in parts) {
            part.isKinematic = false;
            var aux = part.GetComponent<Collider>();
            aux.enabled = false;
            part.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.VelocityChange);
            aux.enabled = true;
        }

    }
}
