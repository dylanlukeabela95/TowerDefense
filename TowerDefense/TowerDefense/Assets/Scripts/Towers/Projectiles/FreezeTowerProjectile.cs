using Strings;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FreezeTowerProjectile : TowerProjectile
{
    public int IceDamage;

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
            GameObject text2 = Instantiate(DamageText.gameObject, other.transform.position, Quaternion.identity);
            text2.GetComponent<TextMeshPro>().text = IceDamage.ToString();
            text2.GetComponent<TextMeshPro>().color = Color.cyan;
        }
    }
}
