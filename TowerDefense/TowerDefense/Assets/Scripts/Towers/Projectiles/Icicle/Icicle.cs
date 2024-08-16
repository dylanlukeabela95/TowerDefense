using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    public GameManager GameManager;

    public float projectileSpeed;

    public int icicleDamage;

    public GameObject target;

    public TextMeshPro DamageText;

    public bool canFrostbite;
    public int frostbiteDamage;
    public float frostbiteTickRate;
    public float slowDuration;
    public float slowEffect;

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
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, projectileSpeed * Time.deltaTime);

            Vector2 directionToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

        //If target is dead but there are still enemies
        if (target == null && GameManager.enemiesInScreen.Count != 0)
        {
            var random = Random.Range(0, GameManager.enemiesInScreen.Count);
            target = GameManager.enemiesInScreen[random];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag) && other.gameObject == target)
        {
            TextMeshPro damageText = Instantiate(DamageText, other.transform.position, Quaternion.identity);

            if(!other.GetComponent<Enemy>().isFrozen)
            {
                other.GetComponent<Enemy>().isFrozen = true;
                other.GetComponent<Enemy>().freezeTimer = slowDuration;
                other.GetComponent<Enemy>().slowEffect = slowEffect;

                if (canFrostbite)
                {
                    other.GetComponent<Enemy>().frostbiteDamage = frostbiteDamage;
                    other.GetComponent<Enemy>().frostbiteTickRate = frostbiteTickRate;
                }    

                damageText.text = icicleDamage.ToString();
                damageText.color = Color.cyan;
            }
            else
            {
                damageText.text = (icicleDamage * 2).ToString();
                damageText.color = Color.cyan;
            }

            Destroy(this.gameObject);
        }
    }
}
