using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FreezeTowerProjectile : TowerProjectile
{
    public int IceDamage;
    public float SlowDuration;
    public float SlowEffect;

    public bool canFrostbite;
    public int frostbiteDamageOverTime;
    public float frostbiteTickRate;

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
            if (IceDamage > 0)
            {
                GameObject text2 = Instantiate(DamageText.gameObject, other.transform.position, Quaternion.identity);
                text2.GetComponent<TextMeshPro>().text = IceDamage.ToString();
                text2.GetComponent<TextMeshPro>().color = Color.cyan;
            }

            if (!other.GetComponent<Enemy>().isFrozen)
            {
                other.GetComponent<Enemy>().isFrozen = true;
                other.GetComponent<Enemy>().freezeTimer = SlowDuration;
                other.GetComponent<Enemy>().slowEffect = SlowEffect;
                
                if(canFrostbite)
                {
                    other.GetComponent<Enemy>().frostbiteDamage = frostbiteDamageOverTime;
                    other.GetComponent<Enemy>().frostbiteTickRate = frostbiteTickRate;
                }
            }
        }
    }
}
