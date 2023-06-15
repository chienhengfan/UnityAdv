using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    public object enemy;
    private object[] _enemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateEnemies(int num)
    {
        object[] _e
        Vector3 vecdir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        if(vecdir.magnitude == 0.0f)
        {
            vecdir.x = 1.0f;
        }

        for(int i, i < num, i++)
        {

        }
    }
}
