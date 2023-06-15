using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletLine : MonoBehaviour
{
    public LineRenderer lr;
    private float fLife;


    public void SetupLine(float distance, float life)
    {
        Debug.Log("SetupLine " + distance);
        lr.SetPosition(0, new Vector3(0, 0, 0));
        lr.SetPosition(1, new Vector3(0, 0, distance));
        fLife = life;
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("BulletLine " + fLife);
        fLife -= Time.deltaTime;
        if(fLife < 0)
        {
            Destroy(gameObject);
        }
    }
}
