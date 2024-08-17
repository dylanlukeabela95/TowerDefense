using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public float MovementSpeed;
    private float x;
    private int y = 1;

    public bool goDown = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.5f);
        x = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!goDown)
        {
            transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * MovementSpeed);
        }
        else
        {
            transform.Translate(new Vector3(x, -y, 0) * Time.deltaTime * MovementSpeed);
        }
    }
}
