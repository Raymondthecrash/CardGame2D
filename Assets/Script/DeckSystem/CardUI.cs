using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< Updated upstream
=======
//
//merged with CardScript but might use again for effects and UI related things
>>>>>>> Stashed changes
public class CardUI : MonoBehaviour
{
    #region Fields and Properties

    private Card _card;

<<<<<<< Updated upstream
    [SerializeField] private Image _cardImage;
    #endregion

=======
    //private CardScript _cardData;

    [SerializeField] private Image _cardImage;
    #endregion



>>>>>>> Stashed changes
    #region Methods

    public void SetCard(Card card)
    {
<<<<<<< Updated upstream
        _cardImage.sprite = _card.CardData.Image;
    }
=======
        if (card != null)
        {
            _card = card; // Store the card reference

            // Set the card image using the CardScript data from the card
            if (_cardImage != null && _card.CardData != null && _card.CardData.Image != null)
            {
                _cardImage.sprite = _card.CardData.Image;
            }
            else
            {
                Debug.LogError("_cardImage, _card or _card.CardData.Image is null!");
            }
        }
        else
        {
            Debug.LogError("_card is null in SetCard!");
        }
    }

    //this was the change in case you need to undo something
    // Call this method to set up the card UI based on the CardScript data
    /*public void SetUp(CardScript cardData)
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

    }*/
>>>>>>> Stashed changes
    #endregion
}
