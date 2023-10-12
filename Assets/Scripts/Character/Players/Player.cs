using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [field: Header("References")]
    [field: SerializeField] public CharacterSO Data { get; private set; }

    [field: Header("GameObject")]
    [field: SerializeField] private Transform AtkPos;
    public Rigidbody Rigidbody { get; private set; }
    public PlayerInput Input { get; private set; }
    public CharacterController Controller { get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }

    public HP HP { get; private set; }
    public Stamina Stamina { get; private set; }

    private PlayerStateMachine stateMachine;

    private float timer_attack;

    private void Awake()
    {

        Rigidbody = GetComponent<Rigidbody>();
        Input = GetComponent<PlayerInput>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();
        HP = GetComponent<HP>();
        Stamina = GetComponent<Stamina>();

        stateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        Init();
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    private void Init()
    {
        Data.Stats.STR.changeStat += HP.SetMaxHP;
        Data.Stats.STR.changeStat += Stamina.SetMaxStamina;

        Data.Stats.AGI.changeStat += HP.SetMaxHP;
        Data.Stats.AGI.changeStat += Stamina.SetMaxStamina;

        Data.Stats.CON.changeStat += HP.SetMaxHP;
        Data.Stats.CON.changeStat += Stamina.SetMaxStamina;
    }

    public void Attack()
    {
        Vector3 dir = transform.localRotation * Vector3.forward;
        dir = dir.normalized;

        Transform bullet = PoolManager.I.Get(0).transform;
        bullet.position = AtkPos.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(1, .5f);
    }
}
