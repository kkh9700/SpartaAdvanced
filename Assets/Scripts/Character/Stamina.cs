using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float MaxStamina;

    public float stamina;
    private ICharacter Character;

    private void Awake()
    {
        Character = GetComponent<ICharacter>();
        SetMaxStamina();
        stamina = MaxStamina;
    }

    public void SetMaxStamina()
    {
        MaxStamina = 100 + Character.Data.Stats.GetPhysicalValue(.3f, .1f, .5f);
    }

    public bool Consume(float a)
    {
        if (stamina < a)
            return false;

        stamina -= a;
        Character.Data.Stats.CON.AddExp(a * .1f);

        return true;
    }

    public void Regenerate(float a)
    {
        stamina += a * (1 + Character.Data.Stats.CON.Level * .01f);

        if (stamina > MaxStamina)
            stamina = MaxStamina;
    }
}