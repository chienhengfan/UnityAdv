using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Object enemyObject;

    private LinkedList<GameObject> aaa;
    private GameObject[] _enemies;  
    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemies(20);
    }

    // Update is called once per frame
    void Update()
    {
       // aaa = new LinkedList<GameObject>();
        
    }

    public void RemoveEnemy(GameObject go)
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] == go)
            {
                _enemies[i] = null;
            }
        }
    }

    private void GenerateEnemies(int num) {

        _enemies = new GameObject[num]; 
        for (int i = 0; i < num; i++)
        {
            GameObject go = GameObject.Instantiate(enemyObject) as GameObject;
            Vector3 vdir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            if(vdir.magnitude < 0.001f)
            {
                vdir.x = 1.0f;
            }
            vdir.Normalize();
            go.transform.position = vdir * Random.Range(10.0f, 20.0f);
            _enemies[i] = go;
        }
    }
}
