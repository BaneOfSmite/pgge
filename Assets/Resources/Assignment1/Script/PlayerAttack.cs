using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    private float attCd = 1;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (attCd < 0) {
            if (Input.GetAxis("Fire1") > 0) {
                StartCoroutine(attackAnim(1));
            }
            if (Input.GetAxis("Fire2") > 0) {
                StartCoroutine(attackAnim(2));
            }
        } else {
            attCd -= Time.deltaTime;
        }
    }

    IEnumerator attackAnim(int attType) {
        attCd = 1;
        transform.GetChild(0).GetComponent<Animator>().SetBool("Attack" + attType, true);
        yield return new WaitForSeconds(1);
        transform.GetChild(0).GetComponent<Animator>().SetBool("Attack" + attType, false);
    }
}
