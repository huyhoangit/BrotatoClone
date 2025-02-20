    using UnityEngine;
using UnityEngine.UI;

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

        public float wanderRadius = 5.0f;
        public float wanderInterval = 2.0f;
        private Vector2 wanderDirection;
        private float wanderTimer;

        public GameObject coin;

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

            wanderTimer = wanderInterval;
            SetRandomWanderDirection();
        }

        void FixedUpdate()
        {
            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            if (player != null)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                rb.linearVelocity = direction * speed;
            }
            else
            {
                Wander();
            }
        }

        private void Wander()
        {
            wanderTimer -= Time.deltaTime;
            if (wanderTimer <= 0)
            {
                SetRandomWanderDirection();
                wanderTimer = wanderInterval;
            }

            rb.linearVelocity = wanderDirection * speed;
        }

        private void SetRandomWanderDirection()
        {
            float angle = Random.Range(0, 2 * Mathf.PI);
            wanderDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        }

        protected override void Die()
        {
            Debug.Log(gameObject.name + " has been defeated!");
            rb.linearVelocity = Vector2.zero;
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.IncreaseScore(1);
        }

        if (coin != null)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }

        base.Die();
        }
    }
