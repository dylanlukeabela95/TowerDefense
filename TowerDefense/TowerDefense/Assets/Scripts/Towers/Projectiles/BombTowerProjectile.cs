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

    public bool canDoubleExplosion;
    public int doubleExplosionChance;

    public int explosionDelay;

    public int nukeChance;

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
            if (explosionDelay == 0)
            {
                Destroy(this.gameObject);
                ApplySplashDamage();
            }
            else
            {
                transform.parent = other.gameObject.transform;
                Destroy(this.gameObject, explosionDelay);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, splashRadius/2);
    }

    //For the delay
    void OnDestroy()
    {
        if(explosionDelay > 0)
        {
            ApplySplashDamage();
        }
    }

    void ApplySplashDamage()
    {
        Collider2D[] colliders = new CircleCollider2D[] { };

        if(nukeChance > 0 && Random.Range(0,101) <= nukeChance)
        {
            colliders = Physics2D.OverlapCircleAll(transform.position, Mathf.Infinity);
        }
        else
        {
            colliders = Physics2D.OverlapCircleAll(transform.position, splashRadius / 2);
        }

        if (canDoubleExplosion)
        {
            var random = Random.Range(0, 101);

            if (random <= doubleExplosionChance)
            {
                foreach (Collider2D collider in colliders)
                {
                    Enemy enemy = collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        //enemy.TakeDamage(damage);

                        TextMeshPro damageText = Instantiate(DamageText, enemy.transform.position, Quaternion.identity);
                        damageText.text = splashDamage.ToString();
                        damageText.color = new Color32(255, 211, 0, 255);

                        TextMeshPro damageText2 = Instantiate(DamageText, enemy.transform.position, Quaternion.identity);
                        damageText2.text = splashDamage.ToString();
                        damageText2.color = new Color32(255, 211, 0, 255);
                    }
                }
            }
            else
            {
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
        else
        {
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

}
