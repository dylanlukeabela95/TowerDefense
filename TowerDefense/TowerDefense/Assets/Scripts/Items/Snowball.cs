using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public TextMeshPro DamageText;

    public int snowballDamage;

    public float projectileSpeed;
    public float stunDuration;

    public GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        if (ReferencesManager.GameManager.enemiesInScreen.Count > 0)
        {
            enemy = ReferencesManager.GameManager.enemiesInScreen[Random.Range(0, ReferencesManager.GameManager.enemiesInScreen.Count)];
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, projectileSpeed * Time.deltaTime);
        }
        else
        {
            if (ReferencesManager.GameManager.enemiesInScreen.Count > 0)
            {
                enemy = ReferencesManager.GameManager.enemiesInScreen[Random.Range(0, ReferencesManager.GameManager.enemiesInScreen.Count)];
            }
            else
            {
                transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag))
        {
            TextMeshPro damageText = Instantiate(DamageText, other.transform.position, Quaternion.identity);
            damageText.color = Color.cyan;
            damageText.text = snowballDamage.ToString();

            if (!other.GetComponent<Enemy>().isStun)
            {
                other.GetComponent<Enemy>().isStun = true;
                other.GetComponent<Enemy>().stunDuration = stunDuration;
            }
            Destroy(this.gameObject);
        }
    }
}
