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
                    GameObject text = Instantiate(DamageText.gameObject, other.transform.position, Quaternion.identity);
                    text.GetComponent<TextMeshPro>().text = Mathf.CeilToInt(markedDamage).ToString();
                    text.GetComponent<TextMeshPro>().color = new Color32(160, 32, 240, 255);
                }
                else if (isCritical)
                {
                    markedDamage = CriticalDamage + (CriticalDamage * (other.GetComponent<Enemy>().markedBonusDamagePercentage * 1.0f / 100));
                    GameObject text = Instantiate(DamageText.gameObject, other.transform.position, Quaternion.identity);
                    text.GetComponent<TextMeshPro>().text = Mathf.CeilToInt(markedDamage).ToString();
                    text.GetComponent<TextMeshPro>().color = Color.yellow;
                }
                else
                {
                    markedDamage = Damage + (Damage * (other.GetComponent<Enemy>().markedBonusDamagePercentage * 1.0f / 100));
                    GameObject text = Instantiate(DamageText.gameObject, other.transform.position, Quaternion.identity);
                    text.GetComponent<TextMeshPro>().text = Mathf.CeilToInt(markedDamage).ToString();
                }
            }
            else
            {
                if (isSuperDamage)
                {
                    GameObject text = Instantiate(DamageText.gameObject, other.transform.position, Quaternion.identity);
                    text.GetComponent<TextMeshPro>().text = superDamage.ToString();
                    text.GetComponent<TextMeshPro>().color = new Color32(160, 32, 240, 255);
                }
                else if (isCritical)
                {
                    GameObject text = Instantiate(DamageText.gameObject, other.transform.position, Quaternion.identity);
                    text.GetComponent<TextMeshPro>().text = CriticalDamage.ToString();
                    text.GetComponent<TextMeshPro>().color = Color.yellow;
                }
                else
                {
                    GameObject text = Instantiate(DamageText.gameObject, other.transform.position, Quaternion.identity);
                    text.GetComponent<TextMeshPro>().text = Damage.ToString();
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
