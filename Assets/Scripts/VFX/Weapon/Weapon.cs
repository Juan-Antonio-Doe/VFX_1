using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] private float cameraSpeed = 10f;

    [SerializeField] private ParticleSystem shootPS;
    [SerializeField] private ParticleSystem impactPS;

    void Update() {
        Vector3 _input = new Vector3(-Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.Translate(_input * Time.deltaTime * cameraSpeed);

        if (Input.GetMouseButton(0)) {
            Shoot();
        }
    }

    void Shoot() {
        shootPS.Play();

        
        if (Physics.Raycast(shootPS.transform.position, shootPS.transform.forward, out RaycastHit _hit, 100f)) {
            impactPS.transform.position = _hit.point;
            impactPS.transform.rotation = Quaternion.LookRotation(_hit.normal);
            impactPS.Play();
        }
    }
}
