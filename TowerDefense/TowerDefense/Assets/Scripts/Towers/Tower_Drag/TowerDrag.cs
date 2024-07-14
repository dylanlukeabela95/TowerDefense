using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDrag : MonoBehaviour
{
    public bool canPlace;
    public GameObject RangeIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canPlace)
        {
            RangeIndicator.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 60 * 1.0f/255);
        }
        else
        {
            RangeIndicator.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 60 * 1.0f/255);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name.Contains("Tower"))
        {
            canPlace = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Tower"))
        {
            canPlace = true;
        }
    }
}
