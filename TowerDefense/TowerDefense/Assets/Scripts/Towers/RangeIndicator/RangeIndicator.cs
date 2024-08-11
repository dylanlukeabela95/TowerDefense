using Strings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag))
        {
            this.gameObject.transform.parent.GetComponent<Tower>().EnemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(StringsDatabase.Tag.EnemyTag) && this.gameObject.transform.parent.GetComponent<Tower>().EnemiesInRange.Contains(other.gameObject))
        {
            this.gameObject.transform.parent.GetComponent<Tower>().EnemiesInRange.Remove(other.gameObject);
        }
    }
}
