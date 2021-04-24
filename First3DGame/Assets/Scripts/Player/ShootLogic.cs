using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootLogic : MonoBehaviour
{
    public Transform Target;
    public GameObject Bullet;

    public Camera Camera;
    public float Damage;

    private Animator animator;

    public Text CountFragsText;
    private void Start()
    {
        animator = transform.parent.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Shoot");
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            Ray ray = Camera.ScreenPointToRay(screenCenter);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                CrabAI enemy = hitObject.GetComponentInChildren<CrabAI>();
                if (hitObject != null && hitObject.tag == "Enemy")
                {
                    enemy.GetDamage(Damage);
                }
                Debug.DrawLine(transform.position, hit.point, Color.green, 6);

            }

        }
        CountFragsText.text = "Frags: " + PlayerStatistics.CountFrags;
    }
}
