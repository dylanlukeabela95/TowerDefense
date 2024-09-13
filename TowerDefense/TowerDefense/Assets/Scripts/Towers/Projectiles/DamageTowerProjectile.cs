using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTowerProjectile : TowerProjectile
{
    public bool isSuperDamage;
    public int superDamage;

    public bool isMarked;

    public bool isBurn;
    public int burnDamage;
    public float burnDuration;
    public float burnTickRate;

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
        if (other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag))
        {
            Destroy(this.gameObject);

            if (other.GetComponent<Enemy>().isMarked)
            {
                float markedDamage = 0;

                if (isSuperDamage)
                {
                    markedDamage = superDamage + (superDamage * (other.GetComponent<Enemy>().markedBonusDamagePercentage * 1.0f / 100));
                    ReferencesManager.GameManager.CreateDamageText(other.gameObject, Mathf.CeilToInt(markedDamage), false, true, false, false, false, false);
                }
                else if (isCritical)
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
                if (isSuperDamage)
                {
                    ReferencesManager.GameManager.CreateDamageText(other.gameObject, superDamage, false, true, false, false, false, false);
                }
                else if (isCritical)
                {
                    ReferencesManager.GameManager.CreateDamageText(other.gameObject, CriticalDamage, true, false, false, false, false, false);
                }
                else
                {
                    ReferencesManager.GameManager.CreateDamageText(other.gameObject, Damage, false, false, false, false, false, false);
                }
            }

            if(isMarked)
            {
                other.GetComponent<Enemy>().isMarked = true;
                other.GetComponent<Enemy>().markedBonusDamagePercentage = 30;
            }

            if(isBurn && !other.GetComponent<Enemy>().isBurn)
            {
                other.GetComponent<Enemy>().isBurn = true;
                other.GetComponent<Enemy>().burnDamage = burnDamage;
                other.GetComponent<Enemy>().burnDuration = burnDuration;
                other.GetComponent<Enemy>().burnTickRate = burnTickRate;
            }
        }
    }
}
