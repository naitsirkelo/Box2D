using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Rigidbody2D rigidbody;
    public Animator animator;

    public float moveLimiter = 0.55f;
    public float verticalLimit = 0.8f;
    public float moveSpeed = 2.0f;
    float horizontal;
    float vertical;
´
    public int waitFrames = 80;
    int count = 40;


    void Start() {

        rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update() {

        rigidbody.freezeRotation = true;

        int h = Random.Range(-1,2);
        int v = Random.Range(-1,2);

        horizontal = (float)h;
        vertical = (float)v;

        count++;

        if (count > waitFrames) {

            animator.SetFloat("LeftRightSpeed", horizontal);
            animator.SetFloat("UpDownSpeed", vertical);

            rigidbody.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed * verticalLimit);
            count = 0;
        }
    }
}
