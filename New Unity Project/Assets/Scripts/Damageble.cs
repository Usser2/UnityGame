using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damageble : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public delegate void GetDamage();
    public event GetDamage DamageDoneEvent;

    void OnCollisionEnter2D(Collider2D obj)
    {
        var component = obj.gameObject.GetComponent<HerosHP>();
        if (component != null)
        {
            DamageDoneEvent(); 
        }
    }

}

