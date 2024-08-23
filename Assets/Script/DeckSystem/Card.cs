using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private void PlayCard()
    {
        Debug.Log($"Playing card: {CardData.CardName}");

        // Notify the ComboSystem that this card was played
        ComboSystem.Instance.OnCardPlayed(CardData);

        // Move this card to the discard pile
        Deck.Instance.Discardpile(this);

        // Any other effects of playing the card...
        
        // call this when a card is played
        //ComboSystem.Instance.OnCardPlayed(playedCard.CardData);

        // End the player's turn
        TurnSystem.Instance.EndPlayerTurn();
    }

    //put this into card class
    public void SetPlayable(bool isPlayable)
    {
        if (_cardButton != null)
        {
            _cardButton.interactable = isPlayable;
        }

        Color cardColor = isPlayable ? Color.white : Color.gray;
        GetComponent<Image>().color = cardColor;
        //_nameText.color = isPlayable ? Color.black : Color.gray;
        //_descriptionText.color = isPlayable ? Color.black : Color.gray;
    }
    #endregion
}
