using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HP : MonoBehaviour
{
    public float MaxHP;
    public float hp;
    private ICharacter Character;
    [field: SerializeField] private Slider mySlider;

    private void Awake()
    {
        Character = GetComponent<ICharacter>();
        SetMaxHP();
        hp = MaxHP;
    }

    private void FixedUpdate()
    {
        DisplaySlider();
    }

    public void SetMaxHP()
    {
        MaxHP = 100 + Character.Data.Stats.GetPhysicalValue(.5f, .2f, 1);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }

    public void Regenerate(float a)
    {
        hp = hp + a > MaxHP ? MaxHP : hp + a;
    }

    private void DisplaySlider()
    {
        mySlider.value = hp / MaxHP;
    }
}