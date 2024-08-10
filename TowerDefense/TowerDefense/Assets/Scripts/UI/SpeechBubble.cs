using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf)
        {
            Vector3 pos = new Vector3(Input.mousePosition.x-110, Input.mousePosition.y+110, Input.mousePosition.z);
            transform.position = pos;
        }
    }
}
