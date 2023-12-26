using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightActiveTile : MonoBehaviour
{
    private TileGraphics highlightedTile;

    void HighlightTile(TileGraphics tile) {
        HideHighlight();
        if(tile != null) tile.setAlpha(1);
        highlightedTile = tile;
    }

    void HideHighlight() {
        if(highlightedTile != null) highlightedTile.setAlpha(0);
        highlightedTile = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        highlightedTile = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TacticalTile tile = GetComponent<TileSelector>().GetMouseoverTile();
            if(tile != null) HighlightTile(tile.GetComponent<TileGraphics>());
            else HideHighlight();
        }
    }
}
