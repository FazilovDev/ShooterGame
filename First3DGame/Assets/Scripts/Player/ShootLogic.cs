using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLogic : MonoBehaviour
{
    public Transform Target;
    public GameObject Bullet;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(Bullet, Target.position, Quaternion.identity);
            var directon = (Target.position - transform.position).normalized;
            bullet.transform.forward = directon;
        }
    }
}
