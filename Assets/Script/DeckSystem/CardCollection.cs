using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *place to group together cards 
 */

[CreateAssetMenu(menuName ="CardCollection")]
public class CardCollection : ScriptableObject
{
    [field:SerializeField] public List<CardScript> CardsInCollection {  get; private set; }

    public void RemovefromCollection(CardScript card)
    {
        if (CardsInCollection.Contains(card))
        {
            CardsInCollection.Remove(card);
        }
        else
        {
            Debug.LogWarning("Card is not in Collection");
        }
    }

    public void AddCardtoCollection(CardScript card)
    {
        CardsInCollection.Add(card);
    }
}
