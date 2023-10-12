using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    public CharacterSO Data { get; }
    public Rigidbody Rigidbody { get; }
    public CharacterController Controller { get; }
    public ForceReceiver ForceReceiver { get; }
    public HP HP { get; }
    public Stamina Stamina { get; }
}
