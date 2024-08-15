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
    private float dummyTickRate;
    private bool firstSetPoison;

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
        Debug.Log(currentWaypointToGo);
        GoToWaypoint();

        Poisoned();
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
            if (dummyTickRate <= 0 && isPoisoned && !firstSetPoison)
            {
                dummyTickRate = poisonTickRate;
                firstSetPoison = true;
            }
            else if (dummyTickRate <= 0 && isPoisoned)
            {
                dummyTickRate = poisonTickRate;
                TextMeshPro damageText = Instantiate(DamageText, transform.position, Quaternion.identity);
                damageText.text = poisonDamage.ToString();
                damageText.color = Color.green;
            }

            dummyTickRate -= Time.deltaTime;
            poisonTimer -= Time.deltaTime;

            if (poisonTimer <= 0)
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

    void GoToWaypoint()
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

            if(waypointCounter >= 2)
            {
                waypointCounter = 0;
            }

            currentWaypointToGo = waypoints[waypointCounter].transform.position;
        }
    }
}
