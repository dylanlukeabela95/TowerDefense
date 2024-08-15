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

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * ProjectileSpeed);
        if(target == null)
        {
            Destroy(this.gameObject);
        }    
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag))
        {
            Destroy(this.gameObject);

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
