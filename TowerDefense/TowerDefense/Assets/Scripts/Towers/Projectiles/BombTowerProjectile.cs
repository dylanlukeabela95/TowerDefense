using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombTowerProjectile : TowerProjectile
{
    public int splashDamage;
    public float splashRadius;
    public GameObject explosionEffect;

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

        if(other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag))
        {
            ApplySplashDamage();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, splashRadius/2);
    }

    void ApplySplashDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, splashRadius/2);
        foreach (Collider2D collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                //enemy.TakeDamage(damage);

                TextMeshPro damageText = Instantiate(DamageText, enemy.transform.position, Quaternion.identity);
                damageText.text = splashDamage.ToString();
                damageText.color = new Color32(255, 211, 0, 255);
            }
        }
    }

}
