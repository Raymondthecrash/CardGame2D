using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CardUI))]
public class Card : MonoBehaviour
{
    #region Fields and Properties

    [field:SerializeField] public CardScript CardData { get; private set; }
    private bool isPlayable;
    [SerializeField] private CardUI _cardUI; // Ensure this is assigned in the Inspector

    #endregion


    #region Methods

    /*Alternative SetUp code
     *  public void SetUp(CardScript cardData)
    {
        if (_cardUI != null)
        {
            _cardUI.SetUp(cardData); // Pass the CardScript data to CardUI
        }
        else
        {
            Debug.LogError("_cardUI is null!");
        }
    }
     */
    public void SetUp(CardScript data)
    {
        //make sue to check later if this double setup's or not
        if (_cardUI != null)
        {
            _cardUI.SetUp(CardData); // Pass the CardScript data to CardUI
        }
        else
        {
            Debug.LogError("_cardUI is null!");
        }
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
    /*public void SetPlayable(bool isPlayable)
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
    */
    // Method to set the card as playable or not playable
    public void SetPlayable(bool playable)
    {
        isPlayable = playable;

        Color cardColor = isPlayable ? Color.white : Color.gray;
        GetComponent<Image>().color = cardColor;

        /*if (_nameText != null)
            _nameText.color = isPlayable ? Color.black : Color.gray;

        if (_descriptionText != null)
            _descriptionText.color = isPlayable ? Color.black : Color.gray;
    */
        

     }

    //incorporate into CardPlay
    private void OnMouseDown()
    {
        if (isPlayable)
        {
            PlayCard();
  
        }
    }
    #endregion
}
