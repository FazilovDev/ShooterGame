using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed;
    public float TimeLife;
    private void Start()
    {
        StartCoroutine(Life());
    }
    private void Update()
    {
        transform.Translate(transform.forward *Speed* Time.deltaTime);
    }

    private IEnumerator Life()
    {
        yield return new WaitForSeconds(TimeLife);
        Destroy(gameObject);
    }
}
