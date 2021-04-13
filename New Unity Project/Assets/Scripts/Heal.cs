using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public delegate void GetHeal();
    public event GetHeal HealDoneEvent;

    void OnTriggerEnter2D(Collider2D obj)
    {
        var component = obj.gameObject.GetComponent<Heal>();
        if (component != null)
        {
            HealDoneEvent();
            Destroy(obj.gameObject);
        }
    }
}