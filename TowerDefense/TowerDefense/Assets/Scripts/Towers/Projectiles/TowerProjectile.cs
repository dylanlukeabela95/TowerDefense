using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
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
                if (isCritical)
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
        }
    }
}
