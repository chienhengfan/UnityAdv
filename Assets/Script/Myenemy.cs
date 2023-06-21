using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myenemy : MonoBehaviour
{
    //[SerializeField]k
    private float _hp;
    private Material _material;
    public Object destroyEffect; 
    // Start is called before the first frame update
    void Start()
    {
        _hp = 100.0f;
        _material = GetComponent<Renderer>().material;
        
    }

    public void Damage(float miunsBlood)
    {
        _hp -= miunsBlood;

        Debug.Log(_hp);
        if (_hp <= 0)
        {
            _hp = 0;
            GameObject gEffect = Instantiate(destroyEffect) as GameObject;
            gEffect.transform.position = transform.position;
            Destroy(gameObject);
        }

        if(_hp >= 30f) 
        {
            _material.color = new Color(1.0f, 1.0f, 1.0f);
        }
        else
        {
            _material.color = new Color(1.0f, 0f, 0f);
        }
    }
}
