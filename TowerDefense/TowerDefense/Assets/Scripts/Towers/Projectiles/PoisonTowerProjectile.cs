using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTowerProjectile : TowerProjectile
{
    public int poisonDamageOverTime;
    public float poisonDuration;
    public float poisonTickRate;

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
            if(!other.GetComponent<Enemy>().isPoisoned)
            {
                other.GetComponent<Enemy>().isPoisoned = true;
                other.GetComponent<Enemy>().poisonDamage = poisonDamageOverTime;
                other.GetComponent<Enemy>().poisonTimer = poisonDuration;
                other.GetComponent<Enemy>().poisonTickRate = poisonTickRate;
            }
        }
    }
}
