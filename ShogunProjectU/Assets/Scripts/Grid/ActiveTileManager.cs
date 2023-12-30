using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTileManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent ActiveTileChangedEvent;

    [SerializeField]
    private GameEvent ActiveTileClickedEvent;

    private void ChangeActiveTile(TacticalTile tile) {
        activeTile = tile;
        ActiveTileChangedEvent.Raise();
    }

    private TacticalTile activeTile;
    public TacticalTile ActiveTile {
        get {return activeTile;}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TacticalTile clickedTile = GetComponent<TileSelector>().GetMouseoverTile();
            if(clickedTile != null) {
                if(clickedTile == activeTile) ActiveTileClickedEvent.Raise();
                else {
                    ChangeActiveTile(clickedTile);
                }
            }
            else ChangeActiveTile(null);
        }
    }
}
