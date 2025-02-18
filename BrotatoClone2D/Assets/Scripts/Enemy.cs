﻿using UnityEngine;

public class Enemy : Character
{
    public EnemyType enemyType;
    public Material tier1Material;
    public Material tier2Material;
    public Material tier3Material;
    public Material tier4Material;

    private Transform player; 
    public float speed = 2.0f; 
    private Rigidbody2D rb;

    protected override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform; 

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            switch (enemyType)
            {
                case EnemyType.TierI:
                    sr.material = tier1Material;
                    break;
                case EnemyType.TierII:
                    sr.material = tier2Material;
                    break;
                case EnemyType.TierIII:
                    sr.material = tier3Material;
                    break;
                case EnemyType.TierIV:
                    sr.material = tier4Material;
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    protected override void Die()
    {
        Debug.Log(gameObject.name + " has been defeated!");
        rb.linearVelocity = Vector2.zero;
        base.Die();
    }
}
