using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//merged with CardScript but might use again for effects and UI related things
public class CardUI : MonoBehaviour
{
    #region Fields and Properties

    private Card _card;

    private CardScript _cardData;

    [SerializeField] private Image _cardImage;
    #endregion

    public void SetCard(Card card)
    {
        _card = card;
        SetCardImage(); // Update the UI when the card is set
    }

    #region Methods
    public void SetCardImage()
    {
        if (_cardImage != null && _card != null)
        {
            _cardImage.sprite = _card.CardData.Image;
        }
        else
        {
            Debug.LogError("_card or _cardImage is null!");
        }
    }

    //this was the change in case you need to undo something
    // Call this method to set up the card UI based on the CardScript data
    public void SetUp(CardScript cardData)
    {
        _cardData = cardData; // Store the card data

        // Set the card image based on the CardScript data
        if (_cardData != null && _cardData.Image != null)
        {
            _cardImage.sprite = _cardData.Image;
        }
        else
        {
            Debug.LogError("_cardData or _cardData.Image is null!");
        }
    }
    #endregion
}
