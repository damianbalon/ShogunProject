using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathfinder
{
    public List<TacticalTile> FindPath(TacticalTile start, TacticalTile end, int jumpHeight = 1)
    {
        List<TacticalTile> openList = new List<TacticalTile>();
        List<TacticalTile> closedList = new List<TacticalTile>();

        openList.Add(start);
        start.G = 0;
        start.H = GetManhattanDistance(start, end);

        while (openList.Count > 0)
        {
            TacticalTile currentTile = openList.OrderBy(x => x.F).First();

            openList.Remove(currentTile);
            closedList.Add(currentTile);

            if (currentTile == end)
            {
                return GenerateFinalPath(start, end);
            }

            var adjacentTiles = GetAdjacentTiles(currentTile, jumpHeight);

            foreach (var adjacent in adjacentTiles)
            {
                if (adjacent.isBlocked || closedList.Contains(adjacent)) continue;
                int newG = currentTile.G + GetManhattanDistance(currentTile, adjacent);

                if (newG < adjacent.G || !openList.Contains(adjacent))
                {
                    adjacent.G = newG;
                    adjacent.H = GetManhattanDistance(end, adjacent);
                    adjacent.previous = currentTile;

                    if (!openList.Contains(adjacent)) openList.Add(adjacent);
                }
            }
        }
        return new List<TacticalTile>();
    }

    private List<TacticalTile> GenerateFinalPath(TacticalTile start, TacticalTile end)
    {
        List<TacticalTile> finalPath = new List<TacticalTile>();
        TacticalTile currentTile = end;
        while (currentTile != start)
        {
            finalPath.Insert(0, currentTile);
            currentTile = currentTile.previous;
        }
        return finalPath;
    }

    private int GetManhattanDistance(TacticalTile start, TacticalTile adjacent)
    {
        return Mathf.Abs(start.GridLocation.x - adjacent.GridLocation.x) + Mathf.Abs(start.GridLocation.y - adjacent.GridLocation.y);
    }

    public List<TacticalTile> GetAdjacentTiles(TacticalTile currentTile, int jumpHeight)
    {
        var map = TacticalMap.Instance.map;
        List<TacticalTile> adjacentTiles = new List<TacticalTile>();
        Vector2Int checkedLocation = new Vector2Int(currentTile.GridLocation.x, currentTile.GridLocation.y + 1);
        if (map.ContainsKey(checkedLocation))
        {
            adjacentTiles.Add(map[checkedLocation]);
        }
        checkedLocation = new Vector2Int(currentTile.GridLocation.x, currentTile.GridLocation.y - 1);
        if (map.ContainsKey(checkedLocation))
        {
            adjacentTiles.Add(map[checkedLocation]);
        }
        checkedLocation = new Vector2Int(currentTile.GridLocation.x + 1, currentTile.GridLocation.y);
        if (map.ContainsKey(checkedLocation))
        {
            adjacentTiles.Add(map[checkedLocation]);
        }
        checkedLocation = new Vector2Int(currentTile.GridLocation.x - 1, currentTile.GridLocation.y);
        if (map.ContainsKey(checkedLocation))
        {
            adjacentTiles.Add(map[checkedLocation]);
        }
        return adjacentTiles;
    }
}
