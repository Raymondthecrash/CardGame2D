using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    #region Fields and Properties

    private Card _card;

    [SerializeField] private Image _cardImage;
    #endregion

    #region Methods
    public void SetCardImage()
    {
        _cardImage.sprite = _card.CardData.Image;
    }
    #endregion
}
