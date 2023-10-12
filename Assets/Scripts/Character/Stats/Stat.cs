using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

[Serializable]
public class Stat
{
    public string StatName;
    [field: SerializeField] private float _level = 1f;
    public float Level
    {
        get
        {
            return _level;
        }
        set
        {

            _level = value;
            changeStat();
        }
    }

    [field: SerializeField] public float Exp { get; private set; } = 0f;

    public delegate void ChangeStat();
    public ChangeStat changeStat;

    public void AddExp(float exp)
    {
        Exp += exp;

        while (Exp >= Level * 1000)
        {
            Exp -= Level * 1000;
            Level += 0.01f;
        }
    }

    public void AddLevel(float level)
    {
        Level += level;
    }
}
