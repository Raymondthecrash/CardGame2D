using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TurnState { START, PLAYERTURN,COMBOTURN,ENEMYTURN,WIN,LOSE}
public class TurnSystem : MonoBehaviour
{
    public TurnState state;
    // Start is called before the first frame update
    void Start()
    {
        state = TurnState.START;
    }

 
}
