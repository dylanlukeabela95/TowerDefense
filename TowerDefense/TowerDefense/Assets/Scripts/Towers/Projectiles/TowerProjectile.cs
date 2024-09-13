using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

    public TextMeshPro DamageText;

    public float ProjectileSpeed;

    public int Damage;
    public int CriticalDamage;

    public bool isCritical;

    public GameObject target;

    public string FromTower;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //transform.Translate(Vector3.up * Time.deltaTime * ProjectileSpeed);   

        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * ProjectileSpeed);
        }
        else
        {
            Destroy(this.gameObject);
        }    
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag))
        {
            if (other.GetComponent<Enemy>().isMarked)
            {
                float markedDamage = 0;

                if (isCritical)
                {
                    markedDamage = CriticalDamage + (CriticalDamage * (other.GetComponent<Enemy>().markedBonusDamagePercentage * 1.0f / 100));
                    ReferencesManager.GameManager.CreateDamageText(other.gameObject, Mathf.CeilToInt(markedDamage), true, false, false, false, false, false);
                }
                else
                {
                    markedDamage = Damage + (Damage * (other.GetComponent<Enemy>().markedBonusDamagePercentage * 1.0f / 100));
                    ReferencesManager.GameManager.CreateDamageText(other.gameObject, Mathf.CeilToInt(markedDamage), false, false, false, false, false, false);
                }
            }
            else
            {
                if (isCritical)
                {
                    ReferencesManager.GameManager.CreateDamageText(other.gameObject, CriticalDamage, true, false, false, false, false, false);
                }
                else
                {
                    ReferencesManager.GameManager.CreateDamageText(other.gameObject, Damage, false, false, false, false, false, false);
                }
            }
        }
    }
}
