using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    public float ProjectileSpeed;

    public int Damage;
    public int CriticalDamage;

    public bool isCritical;

    public GameObject target;

    public bool isInfinityRange;

    // Start is called before the first frame update
    void Start()
    {
        if (!isInfinityRange)
        {
            ProjectileSpeed = 10;
        }
        else
        {
            ProjectileSpeed = 30;
        }
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * ProjectileSpeed);   

        if(target == null)
        {
            Destroy(this.gameObject);
        }    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag))
        {
            Debug.Log("Hit");
            Destroy(this.gameObject);
        }
    }
}
