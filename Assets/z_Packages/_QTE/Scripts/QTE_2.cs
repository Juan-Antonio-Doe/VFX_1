using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_2 : MonoBehaviour {

    [field: SerializeField] private Animator anim;
    [field: SerializeField] private float timeBetweenPresses = 0.1f;
    [field: SerializeField] private KeyCode keyToPress = KeyCode.E;

    [field: SerializeField] private GameObject keyIcon;

    private bool completed;
    private float timer;

    void Start() {

    }

    void Update() {
        if (completed) 
            return;

        //anim.speed = 0f;

        if (keyIcon.activeSelf) {
            keyIcon.SetActive(false);
        } else {
            keyIcon.SetActive(true);
        }

        if (Input.GetKeyDown(keyToPress)) {
            timer = timeBetweenPresses;
            //anim.speed = 5f;
            anim.speed = 1f;
        }

        timer -= Time.deltaTime;

        if (timer <= 0) {
            timer = 0;
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0) {
                anim.speed = -1f;
            }
            else {
                anim.speed = 0f;
            }
        }

    }
}
