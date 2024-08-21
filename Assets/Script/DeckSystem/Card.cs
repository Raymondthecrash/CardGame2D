using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    #region Fields and Properties

    [field: SerializeField] public CardScript CardData { get; private set; }

    #endregion


    #region Methods

    public void SetUp(CardScript data)
    {
        CardData = data;
        GetComponent<CardUI>().SetCardImage();
    }

    #endregion
}
