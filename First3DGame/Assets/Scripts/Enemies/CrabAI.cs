using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CrabAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public float Speed;

    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    public GameObject TargetPlayer;
    public GameObject HealthBar;

    private Animator animator;

    private bool isLife = true;
    public enum State
    {
        Idle = 0,
        Run,
        Attack,
        Die
    }

    public State CurrentState;

    private void Start()
    {
        animator = transform.parent.GetComponentInChildren<Animator>();
        maxHealth = 100f;
        health = maxHealth;
        agent = GetComponentInParent<NavMeshAgent>();
        agent.speed = Speed;
        CurrentState = State.Idle;
    }

    private void Update()
    {
        if (CurrentState == State.Idle)
        {
            CurrentState = State.Run;
        }
        agent.SetDestination(TargetPlayer.transform.position);

        var newX = health / maxHealth;
        var newScale = new Vector3(newX, 0.1f, 0.1f);
        HealthBar.transform.localScale = newScale;

        UpdateHealth();
        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        animator.SetInteger("State", (int)CurrentState);
    }

    private void UpdateHealth()
    {
        if (health == 0)
        {
            CurrentState = State.Die;
            if (isLife)
            {
                isLife = false;
                StartCoroutine(Die());
            }
        }
    }

    public void GetDamage(float damage)
    {
        if (health == 0 && damage > health)
        {
            health = 0;
            return;
        }
        Debug.LogFormat("Health: {0} Damage: {1} NewHealth: {2}", health, damage, health-damage);
        health -= damage;
    }

    private IEnumerator Die()
    {
        Debug.Log("Die");
        agent.speed = 0;
        PlayerStatistics.CountFrags += 1;
        yield return new WaitForSeconds(2f);
        Destroy(transform.parent.gameObject);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
