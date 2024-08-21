using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text NameUnit;
    public Slider HPSlider;
    public int HPText;

    public void SetHUD(PlayerUnit unit)
    {
        NameUnit.text=unit.UnitName;
        HPSlider.maxValue=unit.MaxHealth;
        HPSlider.value=unit.CurrentHealth;
        HPText = unit.CurrentHealth;
    }

    public void SetHP(int hp)
    {
        HPSlider.value=hp;
    }
}
