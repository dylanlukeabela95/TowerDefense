using Strings;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ReferencesManager ReferencesManager;

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
    public int doublePoisonTickRateChance;

    [Header("Freeze")]
    public bool isFrozen;
    public float freezeTimer;
    public float slowEffect;
    public float slowEffectMovementSpeed;
    public int frostbiteDamage;
    public float frostbiteTickRate;
    public float dummyTickRate_Frostbite;
    public bool firstSetFrostbite;
    public bool isImmobilize;

    [Header("Marked")]
    public bool isMarked;
    public int markedBonusDamagePercentage;

    [Header("Burn")]
    public bool isBurn;
    public int burnDamage;
    public float burnDuration;
    public float burnTickRate;
    private float dummyTickRate_Burn;
    private bool firstSetBurn;

    [Header("Snowball")]
    public bool isStun;
    public float stunDuration;

    [Header("Waypoints")]
    public List<GameObject> waypoints = new List<GameObject>();
    private Vector3 currentWaypointToGo;
    private int waypointCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        ReferencesManager = GameObject.FindObjectOfType<ReferencesManager>();

        //SetWaypoints();
        //transform.position = waypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrozen)
        {
            if (isImmobilize || isStun || (isImmobilize && isStun))
            {
                GoToWaypoint(0);
            }
            else
            {
                GoToWaypoint(slowEffectMovementSpeed);
            }
        }
        else if(isStun)
        {
            GoToWaypoint(0);
        }
        else
        {
            GoToWaypoint(movementSpeed);
        }

        Poisoned();
        Slow();
        Burn();
        Stun();
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
                if (doublePoisonTickRateChance > 0 && Random.Range(0, 101) <= doublePoisonTickRateChance)
                {
                    for (int i = 0; i <= 1; i++)
                    {
                        if (ReferencesManager.GameManager.PoisonCriticalChance != 0)
                        {
                            var random = Random.Range(0, 101);
                            if (random <= ReferencesManager.GameManager.PoisonCriticalChance)
                            {
                                ReferencesManager.GameManager.CreateDamageText(this.gameObject, poisonDamage * 2, false, false, false, false, true, false);
                            }
                            else
                            {
                                ReferencesManager.GameManager.CreateDamageText(this.gameObject, poisonDamage, false, false, false, true, false, false);
                            }
                        }
                        else
                        {
                            ReferencesManager.GameManager.CreateDamageText(this.gameObject, poisonDamage, false, false, false, true, false, false);
                        }
                    }
                }
                else
                {
                    if (ReferencesManager.GameManager.PoisonCriticalChance != 0)
                    {
                        var random = Random.Range(0, 101);
                        if (random <= ReferencesManager.GameManager.PoisonCriticalChance)
                        {
                            ReferencesManager.GameManager.CreateDamageText(this.gameObject, poisonDamage * 2, false, false, false, false, true, false);
                        }
                        else
                        {
                            ReferencesManager.GameManager.CreateDamageText(this.gameObject, poisonDamage, false, false, false, true, false, false);
                        }
                    }
                    else
                    {
                        ReferencesManager.GameManager.CreateDamageText(this.gameObject, poisonDamage, false, false, false, true, false, false);
                    }
                }

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
                    ReferencesManager.GameManager.CreateDamageText(this.gameObject, frostbiteDamage, false, false, false, false, false, true);
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

                if(isImmobilize)
                {
                    isImmobilize = false;
                }
            }
        }
    }

    void Burn()
    {
        if (isBurn)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            //If target is poisoned and dummyTickRate is still 0, set it and decrease from it
            if (dummyTickRate_Burn <= 0 && isBurn && !firstSetBurn)
            {
                dummyTickRate_Burn = burnTickRate;
                firstSetBurn = true;
            }
            else if (dummyTickRate_Burn <= 0 && isBurn)
            {
                dummyTickRate_Burn = burnTickRate;
                ReferencesManager.GameManager.CreateDamageText(this.gameObject, burnDamage, false, false, false, false, false, false, true);
            }

            dummyTickRate_Burn -= Time.deltaTime;
            burnDuration -= Time.deltaTime;

            if (burnDuration <= 0)
            {
                isBurn = false;
                dummyTickRate_Burn = 0;
                firstSetBurn = false;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    void Stun()
    {
        if (isStun)
        {
            stunDuration -= Time.deltaTime;

            if(stunDuration <= 0)
            {
                isStun = false;
            }
        }
    }

    void GoToWaypoint(float movementSpeed)
    {
        if (waypoints != null && waypoints.Count > 2)
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

                if (waypointCounter >= 3)
                {
                    waypointCounter = 0;
                }

                currentWaypointToGo = waypoints[waypointCounter].transform.position;
            }
        }
    }
}
