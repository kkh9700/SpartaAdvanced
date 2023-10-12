using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour, ICharacter
{
    [field: Header("References")]
    [field: SerializeField] public CharacterSO Data { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public CharacterController Controller { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }

    public HP HP { get; private set; }
    public Stamina Stamina { get; private set; }

    private void Awake()
    {

        Rigidbody = GetComponent<Rigidbody>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();
        HP = GetComponent<HP>();
        Stamina = GetComponent<Stamina>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
