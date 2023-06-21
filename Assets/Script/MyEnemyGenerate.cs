using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    public Object enemyObject;
    private GameObject[] _enemies;
    void Start()
    {
        GenerateEnemies(20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveEnemy(GameObject ey)
    {
        for(int i = 0; i < _enemies.Length; i++)
        {
            if(_enemies[i] == ey)
            {
                _enemies[i] = null;
            }
        }
    }

    public void GenerateEnemies(int num)
    {
        _enemies = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            Vector3 vecdir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            GameObject enemy = GameObject.Instantiate(enemyObject) as GameObject;

            if (vecdir.magnitude == 0.0f)
            {
                vecdir.x = 1.0f;
            }
            vecdir.Normalize();
            enemy.transform.position = vecdir * Random.Range(5.0f, 20.0f);
            _enemies[i] = enemy;

        }



    }
}
