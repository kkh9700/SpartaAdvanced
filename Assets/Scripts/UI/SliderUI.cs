using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SliderType
{
    HP, Stamina
}

public class SliderUI : MonoBehaviour
{
    private Slider mySlider;
    public SliderType type;
    private void Awake()
    {
        mySlider = GetComponent<Slider>();
    }

    void Start()
    {

    }

    void Update()
    {
        float value = 0f;
        switch (type)
        {
            case SliderType.HP:
                value = GameManager.I.Player.HP.hp / GameManager.I.Player.HP.MaxHP;
                break;
            case SliderType.Stamina:
                value = 0f;
                value = GameManager.I.Player.Stamina.stamina / GameManager.I.Player.Stamina.MaxStamina;
                break;
        }
        mySlider.value = value;
    }
}
