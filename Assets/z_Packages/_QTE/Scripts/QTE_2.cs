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
        anim.SetFloat("Speed", 0);
    }

    void Update() {
        if (completed) 
            return;

        //anim.SetFloat("Speed", 0);

        if (keyIcon.activeSelf) {
            keyIcon.SetActive(false);
        } else {
            keyIcon.SetActive(true);
        }

        if (Input.GetKeyDown(keyToPress)) {
            timer = timeBetweenPresses;
            //anim.speed = 5f;
            anim.SetFloat("Speed", 1);
        }

        timer -= Time.deltaTime;

        if (timer <= 0) {
            timer = 0;
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0) {
                anim.SetFloat("Speed", -1);
            }
            else {
                anim.SetFloat("Speed", 0);
            }
        }
    }

    public void Complete() {
        completed = true;
        anim.SetFloat("Speed", 1);
        keyIcon.SetActive(false);
    }
}
