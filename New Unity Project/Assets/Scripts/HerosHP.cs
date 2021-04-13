using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerosHP : MonoBehaviour

{
    private int HP = 111;
    private Damageble _ObjDamageble = new Damageble();
    private Heal _ObjHeal = new Heal();
    // Start is called before the first frame update
    private void Start()
    {
        _ObjDamageble.DamageDoneEvent += GetDamage;
        _ObjHeal.HealDoneEvent += GetHeal;
    }

    private void Disable()
    {
        _ObjDamageble.DamageDoneEvent -= GetDamage;
        _ObjHeal.HealDoneEvent -= GetHeal;
    }

    // Update is called once per frame
    private void Update()
    {
        OnGUI();
    }

    private void GetDamage()
    {
        this.HP = this.HP - 25;
    }

    private void GetHeal()
    {
        this.HP = this.HP + 50;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), "Life=" + this.HP);
    }

}
