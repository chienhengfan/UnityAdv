using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour
{
    ParticleSystem[] pss;
    // Start is called before the first frame update
    void Start()
    {
        pss = GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < pss.Length; i++)
        {
            if (pss[i].isPlaying)
            {
                return;
            }
            Destroy(gameObject);
        }
    }
}
