using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    #region Fields and Properties

    public static Deck Instance { get; private set; } //Singleton

    [SerializeField] private CardCollection _PlayerDeck;
    [SerializeField] private Card _CardPrefab;

    [SerializeField] private Canvas _cardCanvas;

    private List<Card> _Deckpile;
    private List<Card> _Discardpile;

    public List<Card> Handcards;
    #endregion

    #region Methods
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void InstantiateDeck()
    {
        for (int i = 0; i < _PlayerDeck.CardsInCollection.Count; i++)
        {
            Card card = Instantiate(_CardPrefab, _cardCanvas.transform); //instantiates the Card Prefab as child of the Card Canvas == as UI
            card.SetUp(_PlayerDeck.CardsInCollection[i]);
            _Deckpile.Add(card); //at the start, all cards are in the deck, none in hand, none in discard
            card.gameObject.SetActive(false); //we will later activate the cards when we draw them, for now we just want to build the pool
        }

        ShuffleDeck();
    }

    private void ShuffleDeck()
    {
        for(int i=_Deckpile.Count-1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            var temp=_Deckpile[i];

            _Deckpile[i]= _Deckpile[j];
            _Deckpile[j]= temp;
        } 
    }

    public void DrawHand()
    {
        int amount = TurnSystem.AvailCardSlots.Length;
        for(int i= 0; 1 < amount; i++)
        {
            if (_Deckpile.Count <= 0)
            {
                _Discardpile = _Deckpile;
                _Discardpile.Clear();
                ShuffleDeck();
            }
            Handcards.Add(_Deckpile[0]);
            _Deckpile[0].gameObject.SetActive(true);
            _Deckpile.RemoveAt(0);
        }
    }

    public void Discardpile(Card card)
    {
        if (Handcards.Contains(card))
        {
            Handcards.Remove(card);
            _Discardpile.Add(card);
            card.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        InstantiateDeck();
    }
    private void OnEnable()
    {
        TurnSystem.Instance.OnPlayerTurnStart.AddListener(DrawHand);
    }

    private void OnDisable()
    {
        TurnSystem.Instance.OnPlayerTurnStart.RemoveListener(DrawHand);
    }
    #endregion
}
