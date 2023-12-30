using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Found using GameEvent without it looking dirty a little tricky so I did this instead
public class PartyMoveCommand : GameEventListener
{
    private PartyMovement movementModule;
    [SerializeField] private ActiveTileManager activeTileSource;
    void Update() {
        if(movementModule == null) {
            movementModule = GetComponentInParent<PartyMovement>();
            if(GetComponentInParent<PartyMovement>() == null) {
                Debug.Log("No Party Movement script detected in parent object. The Move Command will now terminate.");
                Destroy(this);
            }
        }
        if(activeTileSource == null) {
            Debug.Log("No reference to active tile manager. The Move Command will now terminate.");
            Destroy(this);
        }
    }
    public override void OnEventRaised() {
        Response.Invoke();
        movementModule.MoveTowardsTile(activeTileSource.ActiveTile);
    }

    public PartyMoveCommand(PartyMovement movement, ActiveTileManager tileSource) {
        movementModule = movement;
        activeTileSource = tileSource;
    }
}
