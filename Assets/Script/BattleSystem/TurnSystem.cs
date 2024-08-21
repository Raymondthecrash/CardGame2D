using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TurnState { START, PLAYERTURN,COMBOTURN,ENEMYTURN,WIN,LOSE}
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
