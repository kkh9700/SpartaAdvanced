using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Character/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    [field: SerializeField] public Stats Stats { get; private set; }
    [field: SerializeField] public CharacterGroundData GroundData { get; private set; }
    [field: SerializeField] public CharacterAirData AirData { get; private set; }
}
