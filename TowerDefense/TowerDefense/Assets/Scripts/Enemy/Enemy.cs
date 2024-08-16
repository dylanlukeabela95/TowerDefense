using Strings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float movementSpeed;

    [Header("Damage Text")]
    public TextMeshPro DamageText;

    [Header("Poison")]
    public bool isPoisoned;
    public float poisonTimer;
    public int poisonDamage;
    public float poisonTickRate;
    private float dummyTickRate_Poison;
    private bool firstSetPoison;

    [Header("Freeze")]
    public bool isFrozen;
    public float freezeTimer;
    public float slowEffect;
    public float slowEffectMovementSpeed;
    public int frostbiteDamage;
    public float frostbiteTickRate;
    public float dummyTickRate_Frostbite;
    public bool firstSetFrostbite;

    [Header("Waypoints")]
    public List<GameObject> waypoints = new List<GameObject>();
    private Vector3 currentWaypointToGo;
    private int waypointCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetWaypoints();
        transform.position = waypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrozen)
        {
            GoToWaypoint(slowEffectMovementSpeed);
        }
        else
        {
            GoToWaypoint(movementSpeed);
        }

        Poisoned();
        Slow();
    }

    void SetWaypoints()
    {
        GameObject waypointParent = GameObject.Find(StringsDatabase.Enemy.Waypoints);

        for(int i = 0; i < waypointParent.transform.childCount;i++)
        {
            waypoints.Add(waypointParent.transform.GetChild(i).gameObject);
        }
    }

    void Poisoned()
    {
        if (isPoisoned)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            //If target is poisoned and dummyTickRate is still 0, set it and decrease from it
            if (dummyTickRate_Poison <= 0 && isPoisoned && !firstSetPoison)
            {
                dummyTickRate_Poison = poisonTickRate;
                firstSetPoison = true;
            }
            else if (dummyTickRate_Poison <= 0 && isPoisoned)
            {
                dummyTickRate_Poison = poisonTickRate;
                TextMeshPro damageText = Instantiate(DamageText, transform.position, Quaternion.identity);
                damageText.text = poisonDamage.ToString();
                damageText.color = Color.green;
            }

            dummyTickRate_Poison -= Time.deltaTime;
            poisonTimer -= Time.deltaTime;

            if (poisonTimer <= 0)
            {
                isPoisoned = false;
                dummyTickRate_Poison = 0;
                firstSetPoison = false;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    void Slow()
    {
        if (isFrozen)
        {
            //can frostbite
            if(frostbiteDamage != 0)
            {
                if (dummyTickRate_Frostbite <= 0 && isFrozen && !firstSetFrostbite)
                {
                    dummyTickRate_Frostbite = frostbiteTickRate;
                    firstSetFrostbite = true;
                }
                else if (dummyTickRate_Frostbite <= 0 && isFrozen)
                {
                    dummyTickRate_Frostbite = frostbiteTickRate;
                    TextMeshPro damageText = Instantiate(DamageText, transform.position, Quaternion.identity);
                    damageText.text = frostbiteDamage.ToString();
                    damageText.color = Color.cyan;
                }

                dummyTickRate_Frostbite -= Time.deltaTime;
            }

            freezeTimer -= Time.deltaTime;

            if (slowEffectMovementSpeed == 0)
            {
                slowEffectMovementSpeed = movementSpeed - (movementSpeed * 2 * ((slowEffect * 1.0f) / 100));
            }

            if (freezeTimer <= 0)
            {
                isFrozen = false;
                slowEffectMovementSpeed = 0;
                dummyTickRate_Frostbite = 0;
                firstSetFrostbite = false;
            }
        }
    }

    void GoToWaypoint(float movementSpeed)
    {
        if (currentWaypointToGo == Vector3.zero)
        {
            currentWaypointToGo = waypoints[1].transform.position;
        }

        if (transform.position != currentWaypointToGo)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypointToGo, movementSpeed * Time.deltaTime);
        }
        else
        {
            waypointCounter++;

            if(waypointCounter >= 3)
            {
                waypointCounter = 0;
            }

            currentWaypointToGo = waypoints[waypointCounter].transform.position;
        }
    }
}
