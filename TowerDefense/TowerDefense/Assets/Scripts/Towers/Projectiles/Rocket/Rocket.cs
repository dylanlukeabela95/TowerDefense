using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameManager GameManager;

    public GameObject target;

    public TextMeshPro DamageText;

    public int rocketDamage;
    public int splashDamage;
    public float splashRadius;

    public float rocketMovementSpeed;

    public bool canDoubleExplosion;
    public int doubleExplosionChance;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindObjectOfType<GameManager>();

        var random = Random.Range(0, GameManager.enemiesInScreen.Count);
        target = GameManager.enemiesInScreen[random];
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, rocketMovementSpeed * Time.deltaTime);

            Vector2 directionToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

        if (target == null && GameManager.enemiesInScreen.Count > 0)
        {
            var random = Random.Range(0, GameManager.enemiesInScreen.Count);
            target = GameManager.enemiesInScreen[random];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag) && target == other.gameObject)
        {
            GameManager.CreateDamageText(other.gameObject, rocketDamage, false, false, false, false, false, false);

            ApplySplashDamage();

            Destroy(this.gameObject);
        }
    }

    void ApplySplashDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, splashRadius / 2);

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
                        GameManager.CreateDamageText(enemy.gameObject, splashDamage, false, false, true, false, false, false);
                        GameManager.CreateDamageText(enemy.gameObject, splashDamage, false, false, true, false, false, false);
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
                        GameManager.CreateDamageText(enemy.gameObject, splashDamage, false, false, true, false, false, false);
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
                    GameManager.CreateDamageText(enemy.gameObject, splashDamage, false, false, true, false, false, false);
                }
            }
        }

    }
}
