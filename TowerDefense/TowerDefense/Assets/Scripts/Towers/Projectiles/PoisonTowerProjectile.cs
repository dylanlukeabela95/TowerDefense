using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoisonTowerProjectile : TowerProjectile
{
    [Header("Poison Stats")]
    public int poisonDamageOverTime;
    public float poisonDuration;
    public float poisonTickRate;

    [Header("Poison Spread")]
    public bool poisonSpread;
    public float poisonSpreadRadius;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag))
        {
            if (!other.GetComponent<Enemy>().isPoisoned)
            {
                other.GetComponent<Enemy>().isPoisoned = true;
                other.GetComponent<Enemy>().poisonDamage = poisonDamageOverTime;
                other.GetComponent<Enemy>().poisonTimer = poisonDuration;
                other.GetComponent<Enemy>().poisonTickRate = poisonTickRate;
            }

            if(poisonSpread)
            {
                ApplyPoisonSpread();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, poisonSpreadRadius);
    }

    public void ApplyPoisonSpread()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, poisonSpreadRadius);
        foreach (Collider2D collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                //enemy.TakeDamage(damage);

                if (!enemy.isPoisoned)
                {
                    enemy.isPoisoned = true;
                    enemy.poisonDamage = poisonDamageOverTime;
                    enemy.poisonTimer = poisonDuration;
                    enemy.poisonTickRate = poisonTickRate;
                }
            }
        }
    }
}
