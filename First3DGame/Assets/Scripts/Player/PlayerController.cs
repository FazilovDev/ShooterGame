using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public float speed;
    public bool isMove;
    public float Jump;
    public float Health;
    public bool IsJump;
    public bool isSeet = false;
    public Transform Target;

    public GameObject prefabBullet;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isMove = false;
        Health = 100;
        ActivateAnimation("Idle");
    }

    private void ResetAnimations()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
        animator.SetBool("IdleDaking", false);
    }

    private void ActivateAnimation(string nameAnimation)
    {
        ResetAnimations();
        animator.SetBool(nameAnimation, true);
    }

    private void Update()
    {
        Vector3 movement = Vector3.zero;
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        if (movement == Vector3.zero)
        {
            if (!isSeet)
                ActivateAnimation("Idle");
        }
        else
        {
            ActivateAnimation("Run");
        }
        var vectorMove = movement * speed;
        vectorMove.y = transform.position.y;
        var direction = (vectorMove - transform.position).normalized;
        transform.forward = direction;
        transform.Translate(vectorMove * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Shoot");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            isSeet = !isSeet;
            if (isSeet == true)
            {
                ActivateAnimation("IdleDaking");
            }
        }
    }

}
