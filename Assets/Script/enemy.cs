using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float _hp;
    private Material _material;
    public Object destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        _hp = 100.0f;
        _material = GetComponent<Renderer>().material;
    }

    public void Damage(float minus)
    {
      
        _hp -= minus;
        Debug.Log(_hp);
        if (_hp <= 0)
        {
            _hp = 0;
            GameObject gEffect = Instantiate(destroyEffect) as GameObject;
            gEffect.transform.position = transform.position;
            Destroy(gameObject);
        }

        if (_hp > 50)
        {
            _material.color = new Color(1.0f, 1.0f, 1.0f);
        } 
        else
        {
            _material.color = new Color(1.0f, 0.0f, 0.0f);
        }

    }

    

}
