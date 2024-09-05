using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*public enum TurnState { START, PLAYERTURN,COMBOTURN,ENEMYTURN,WIN,LOSE}
public class TurnSystem : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    public Transform EnemyBattleStation;

    EnemyUnit Enemy;
    PlayerUnit Player;

    public BattleHUD PlayerHUD;
    public BattleHUD EnemyHUD;

    public TurnState state;
    // Start is called before the first frame update
    void Start()
    {
        state = TurnState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject PlayerGO=Instantiate(PlayerPrefab);
        Player=PlayerGO.GetComponent<PlayerUnit>();

        GameObject EnemyGO=Instantiate(EnemyPrefab, EnemyBattleStation);
        Enemy = EnemyGO.GetComponent<EnemyUnit>();

        PlayerHUD.SetHUD(Player);

    } 
}
*/
public enum GameState
{
    StartOfBattle,
    PlayerTurn,
    EnemyTurn,
    Win,
    Loss
}

public class TurnSystem : MonoBehaviour
{
    public Transform[] CardSlots;
    public bool[] AvailCardSlots;
    EnemyManager enemyManager;
    PlayerManager playerManager;
    public static TurnSystem Instance { get; private set; }

    public GameState CurrentState { get; private set; }

    // Events for different state changes
    public UnityEvent OnBattleStart;
    public UnityEvent OnPlayerTurnStart;
    public UnityEvent OnEnemyTurnStart;
    public UnityEvent OnWin;
    public UnityEvent OnLoss;

    [SerializeField] private float turnDelay = 0.5f; // Delay between turns

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

    private void Start()
    {
        Awake(); 
        StartBattle();
    }

    public void StartBattle()
    {
        CurrentState = GameState.StartOfBattle;
        OnBattleStart.Invoke();

        // Initialize enemies here
        EnemyManager.Instance.InitializeEnemies();

        // Transition to player turn after a short delay
        StartCoroutine(TransitionToState(GameState.PlayerTurn));
    }

    public void StartPlayerTurn()
    {
        Deck.Instance.DrawHand();
        EndPlayerTurn();
    }

    public void EndPlayerTurn()
    {
        if (CurrentState != GameState.PlayerTurn) return;
        StartCoroutine(TransitionToState(GameState.EnemyTurn));
    }

    public void EndEnemyTurn()
    {
        if (CurrentState != GameState.EnemyTurn) return;
        StartCoroutine(TransitionToState(GameState.PlayerTurn));
    }

    public void WinBattle()
    {
        CurrentState = GameState.Win;
        OnWin.Invoke();
    }

    public void LoseBattle()
    {
        CurrentState = GameState.Loss;
        OnLoss.Invoke();
    }

    private IEnumerator TransitionToState(GameState newState)
    {
        yield return new WaitForSeconds(turnDelay);

        CurrentState = newState;

        switch (newState)
        {
            case GameState.PlayerTurn:
                OnPlayerTurnStart.Invoke();
                break;
            case GameState.EnemyTurn:
                OnEnemyTurnStart.Invoke();
                StartCoroutine(ProcessEnemyTurn());
                break;
        }
    }

    private IEnumerator ProcessEnemyTurn()
    {
        // Simulate enemy actions
        PlayerManager.Instance.TakeDamage(50);
        yield return new WaitForSeconds(1f); // Simulated enemy turn duration

        // Check for win/loss conditions after enemy turn
        if (CheckWinCondition())
        {
            WinBattle();
        }
        else if (CheckLossCondition())
        {
            LoseBattle();
        }
        else
        {
            EndEnemyTurn();
        }
    }

    private bool CheckWinCondition()
    {
        // Implement your win condition logic here
        // For example, check if all enemies are defeated
        return EnemyManager.Instance.AllEnemiesDefeated();
    }

    private bool CheckLossCondition()
    {
        // Implement your loss condition logic here
        // For example, check if player's health is zero
            return PlayerManager.Instance.IsPlayerDefeated();
    }

}
