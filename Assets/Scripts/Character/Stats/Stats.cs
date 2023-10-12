using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats
{
    [field: Header("Physical")]
    [field: SerializeField] public Stat STR { get; private set; }
    [field: SerializeField] public Stat AGI { get; private set; }
    [field: SerializeField] public Stat CON { get; private set; }

    [field: Header("Mental")]
    [field: SerializeField] public Stat INT { get; private set; }
    [field: SerializeField] public Stat WIS { get; private set; }
    [field: SerializeField] public Stat CHA { get; private set; }

    public float GetPhysicalValue(float strModifier, float agiModifier, float conModifier)
    {
        return STR.Level * strModifier + AGI.Level * agiModifier + CON.Level + conModifier;
    }

    public float GetMentalValue(float intModifier, float wisModifier, float chaModifier)
    {
        return INT.Level * intModifier + WIS.Level * wisModifier + CHA.Level + chaModifier;
    }

    public float GetTotalValue(float strModifier, float agiModifier, float conModifier, float intModifier, float wisModifier, float chaModifier)
    {
        return GetPhysicalValue(strModifier, agiModifier, conModifier) + GetMentalValue(intModifier, wisModifier, chaModifier);
    }
}
