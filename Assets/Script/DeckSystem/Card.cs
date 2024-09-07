using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
<<<<<<< Updated upstream

=======
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
[RequireComponent(typeof(CardUI))]
>>>>>>> Stashed changes
public class Card : MonoBehaviour
{
    #region Fields and Properties

    [field: SerializeField] public CardScript CardData { get; private set; }

    #endregion


    #region Methods

<<<<<<< Updated upstream
    public void SetUp(CardScript data)
    {
        CardData = data;
        GetComponent<CardUI>().SetCardImage();
=======
    
    public void SetUp(CardScript data)
    {
        //make sue to check later if this double setup's or not
        if (_cardUI != null)
        {
            _cardUI.SetCard(this); // Pass the CardScript data to CardUI
            //GetComponent<CardUI>().SetCardImage();
        }
        else
        {
            Debug.LogError("_cardUI is null!");
        }
        
>>>>>>> Stashed changes
    }
    private void PlayCard()
    {
        Debug.Log($"Playing card: {CardData.CardName}");

        // Notify the ComboSystem that this card was played
        ComboSystem.Instance.OnCardPlayed(CardData);

        // Move this card to the discard pile
        Deck.Instance.Discardpile(this);

        // Any other effects of playing the card...

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

    // call this when a card is played
    ComboSystem.Instance.OnCardPlayed(playedCard.CardData);
    #endregion
}
