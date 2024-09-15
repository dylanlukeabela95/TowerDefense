using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public int musicVolume = 50;
    public int soundEffectVolume = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlterVolume(bool isMusic, bool isSoundEffect, bool isAdd, bool isSubtract)
    {
        if (isMusic)
        {
            if(isAdd)
            {
                if (musicVolume + 5 <= 100)
                {
                    musicVolume += 5;
                }
            }
            else if (isSubtract)
            {
                if (musicVolume - 5 >= 0)
                {
                    musicVolume -= 5;
                }
            }
        }

        if(isSoundEffect)
        {
            if (isAdd)
            {
                if (soundEffectVolume + 5 <= 100)
                {
                    soundEffectVolume += 5;
                }
            }
            else if (isSubtract)
            {
                if (soundEffectVolume - 5 >= 0)
                {
                    soundEffectVolume -= 5;
                }
            }
        }
    }
}
