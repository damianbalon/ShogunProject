using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private GameEvent endTurnEvent;
    [SerializeField] private GameEvent nextActionEvent;
    private List<CombatBehavior> combatants;
    private List<Tuple<CombatBehavior, int>> turnOrder;
    private GameObject currentActor;
    // Start is called before the first frame update
    void Start()
    {
        turnOrder = new List<Tuple<CombatBehavior, int>>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConstructTurnOrder() {
        turnOrder.Clear();
        foreach(var item in combatants) {
            turnOrder.Add(new Tuple<CombatBehavior, int>(item, item.Initiative));
        }
        turnOrder.Sort((x, y) => x.Item2.CompareTo(y.Item2));
        currentActor = turnOrder[turnOrder.Count - 1].Item1.gameObject;
    }

    void NextAction() {
        turnOrder.RemoveAt(turnOrder.Count - 1);
        if(turnOrder.Count == 0) {
            endTurnEvent.Raise();
            ConstructTurnOrder();
        }
        else currentActor = turnOrder[turnOrder.Count - 1].Item1.gameObject;
    }
}
