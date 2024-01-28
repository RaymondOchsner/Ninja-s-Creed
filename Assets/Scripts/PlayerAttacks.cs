using System;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private float attackTime;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayer;
    private float cooldownTimer = Mathf.Infinity; //unendlich damit zu Beginn des Spiels attack benutzt werden kann
    private Animator animator;
    private MovementPlayer player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<MovementPlayer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackTime && player.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        cooldownTimer = 0;
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, attackRange, enemyLayer);
        if (enemy != null)
            enemy.GetComponent<Health>().TakeDamage(1);
    }
}
