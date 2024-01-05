using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameEvent endTurnEvent;
    //[SerializeField] private GameEvent endActionEvent; może to będzie odbierał gdy postać skończy turę a nie samemu wysyłał
    private List<CombatBehavior> combatants;
    private List<Tuple<CombatBehavior, int>> turnOrder;
    private CombatBehavior currentActor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
