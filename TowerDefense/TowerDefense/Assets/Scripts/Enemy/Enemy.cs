using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Damage Text")]
    public TextMeshPro DamageText;

    [Header("Poison")]
    public bool isPoisoned;
    public float poisonTimer;
    public int poisonDamage;
    public float poisonTickRate;
    private float dummyTickRate;
    private bool firstSetPoison;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPoisoned)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            //If target is poisoned and dummyTickRate is still 0, set it and decrease from it
            if (dummyTickRate <= 0 && isPoisoned && !firstSetPoison)
            {
                dummyTickRate = poisonTickRate;
                firstSetPoison = true;
            }
            else if(dummyTickRate <= 0 && isPoisoned)
            {
                dummyTickRate = poisonTickRate;
                TextMeshPro damageText = Instantiate(DamageText, transform.position, Quaternion.identity);
                damageText.text = poisonDamage.ToString();
                damageText.color = Color.green;
            }

            dummyTickRate -= Time.deltaTime;
            poisonTimer -= Time.deltaTime;

            if(poisonTimer <= 0 )
            {
                isPoisoned = false;
            }
        }
        else
        {
            dummyTickRate = 0;
            firstSetPoison = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }


    }



}
