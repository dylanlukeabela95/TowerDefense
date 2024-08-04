using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    public float ProjectileSpeed;

    public int Damage;
    public int CriticalDamage;

    public bool isCritical;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * ProjectileSpeed);   
    }
}
