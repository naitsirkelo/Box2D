using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rigidbody;
    public Animator animator;

    float horizontal;
    float vertical;

    public float moveLimiter = 0.65f;
    public float verticalLimit = 0.8f;
    public float runSpeed = 2.5f;


    void Start () {

       rigidbody = GetComponent<Rigidbody2D>();

       //Physics2D.LayerCollision(13, 0);

    }

    void Update () {

       horizontal = Input.GetAxisRaw("Horizontal");
       vertical = Input.GetAxisRaw("Vertical");

       animator.SetFloat("LeftRightSpeed", horizontal);
       animator.SetFloat("UpDownSpeed", vertical);
       animator.SetFloat("MoveSpeed", Mathf.Abs(horizontal)+Mathf.Abs(vertical));

    }

    private void FixedUpdate() {

        rigidbody.freezeRotation = true;

        if (horizontal != 0 && vertical != 0) {

            horizontal *= moveLimiter;
            vertical *= moveLimiter;

        }

        rigidbody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed * verticalLimit);

    }
}
