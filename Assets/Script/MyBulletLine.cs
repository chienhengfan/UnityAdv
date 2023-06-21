using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBulletLine : MonoBehaviour
{
    public LineRenderer lr;
    private float bulletLife;
    // Start is called before the first frame update
    public void SetupLine(float distance, float life)
    {
        lr.SetPosition(0, new Vector3(0, 0, 0));
        lr.SetPosition(0, new Vector3(1, 0, distance));

        bulletLife = life;
        this.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        bulletLife -= Time.deltaTime;
        if (bulletLife < 0)
        {
            Destroy(gameObject);
        }
    }
}
