using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour {

    public FrogController2D controller;
    public Animator animator;
    Rigidbody m_Rigidbody;

    public int waitFrames = 130;
    public int jumpingFrames = 30;
    public int speed = 20;
    public float minForce = 0.03f, maxForce = 0.5f, minJump = 0.1f, maxJump = 0.3f;

    int count = 0, jumping = 0;
    float randSpeed = 0.0f, randJump = 0.0f, dir;

    bool randCount = false, facingLeft = true, setup = false;

    void Flip() {

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    // Update is called once per frame
    void Update() {

        if (!randCount)  {

            float n = Random.Range(0.0f, 1.0f);

            if      (n < 0.1f) waitFrames = 10;
            else if (n > 0.9f) waitFrames = 190;
            else if (n > 0.6f) waitFrames = 70;
            else               waitFrames = 130;

            randCount = true;
        }
        count++;

        if (count > waitFrames) {

            animator.SetBool("Jump", true);

            if (!setup)  {
                randSpeed = Random.Range(minForce, maxForce);
                randJump = Random.Range(minJump, maxJump);
                dir = Random.Range(0.0f, 1.0f);
                setup = true;
            }

            if (dir > 0.5f) {

                if (!facingLeft) Flip();

                Vector3 move = new Vector3(-randSpeed, randJump, 0.0f);
                transform.position = transform.position + move * speed * Time.deltaTime;

                facingLeft = true;

            } else {

                if (facingLeft) Flip();

                Vector3 move = new Vector3(randSpeed, randJump, 0.0f);
                transform.position = transform.position + move * speed * Time.deltaTime;

                facingLeft = false;

            }

            jumping++;

            if (jumping > jumpingFrames) {

                animator.SetBool("Jump", false);

                count = 0;
                jumping = 0;
                setup = false;
                randCount = false;

            }
        }
    }
}
