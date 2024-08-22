using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    #region Singleton
    public static ComboSystem Instance { get; private set; }
    #endregion

    #region Fields and Properties
    [SerializeField] private int _lastPlayedComboCount = -1;
    #endregion

    #region Methods
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnCardPlayed(CardScript card)
    {
        _lastPlayedComboCount = card.ComboCount;
        UpdatePlayableCards();
    }

    public void UpdatePlayableCards()
    {
        if (Deck.Instance != null && Deck.Instance.Handcards != null)
        {
            foreach (Card card in Deck.Instance.Handcards)
            {
                card.SetPlayable(IsCardPlayable(card.CardData));
            }
        }
    }

    private bool IsCardPlayable(CardScript cardData)
    {
        return _lastPlayedComboCount == -1 ||
            cardData.ComboCount == _lastPlayedComboCount ||
            cardData.ComboCount == _lastPlayedComboCount + 1 ||
            cardData.ComboCount == _lastPlayedComboCount - 1;
    }

    public void EndTurn()
    {
        _lastPlayedComboCount = -1;//masukin this stuff to the end turn thing
        UpdatePlayableCards();
    }
    #endregion
}