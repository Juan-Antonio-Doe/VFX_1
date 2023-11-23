using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_1 : MonoBehaviour {

    [field: SerializeField] private Animator anim;
    [field: SerializeField] private float timeToReact = 0.5f;
    [field: SerializeField] private KeyCode keyToPress = KeyCode.E;
    [field: SerializeField] private float slowMotionSpeed = 0.2f;

    [field: SerializeField] private GameObject keyIcon;

    private bool canInteract;
    private float timer;
	
    void Start() {
        
    }

    void Update() {
        if (canInteract) {

            // Show & Hide Key Icon fast.
            if (keyIcon.activeSelf) {
                keyIcon.SetActive(false);
            } else {
                keyIcon.SetActive(true);
            }

            timer += Time.deltaTime;

            if (timer >= timeToReact) {
                ResetQTE();
                return;
            }

            if (Input.GetKeyDown(keyToPress)) {
                ResetQTE();
                anim.SetBool("Success", true);
            }
        }
    }

    void CanInteract() {
        canInteract = true;
        anim.speed = slowMotionSpeed;
    }

    void ResetQTE() {
        anim.speed = 1f;
        canInteract = false;
        keyIcon.SetActive(false);
    }
}
