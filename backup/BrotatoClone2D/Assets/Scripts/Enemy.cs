using UnityEngine;

public class Enemy : Character
{
    public EnemyType enemyType;
    public Material tier1Material;
    public Material tier2Material;
    public Material tier3Material;
    public Material tier4Material;

    protected override void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

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
        base.Start();
    }
    protected override void Die()
    {
        Debug.Log(gameObject.name + " has been defeated!");
        base.Die();
    }
}
