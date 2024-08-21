using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * simple card storage
 */

[CreateAssetMenu(menuName = "CardData")]
public class CardScript : ScriptableObject
{
    [field: SerializeField] public string CardName { get; private set; }
    [field: SerializeField, TextArea] public string CardDescription { get; private set; } //TextArea makes an input field in the inspector to write longer text in
    
    [field: SerializeField] public int ComboCount { get; private set; }
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: SerializeField] public CardElement Element { get; private set; }
    [field:SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public CardEffectType EffectType { get; private set; }
}

public enum CardElement
{
   Bio,
   Xeno,
   Mech
}

public enum CardEffectType
{
    None,
    Poison,
    Bleed,
    Healing,
    Bound
}
