using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//MUSISZ TO PODPIĄĆ DO OBIEKTU Z KLASĄ PARTYMANAGER
public class PartyMovement : MonoBehaviour
{
    private PartyManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<PartyManager>();
        //Debug.Log(manager.Party.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTowardsTile(TacticalTile tile) {
        var path = Pathfinder.FindPath(manager.Party[0].GetComponent<CharacterMove>().OccupiedTile, tile);
        Debug.Log("Długość drogi: " + path.Count);
        manager.Party[0].GetComponent<CharacterMove>().Path = path;
        int n = manager.Party.Count, i = 1;
        while(i < n && path.Count > 0) {
            path.RemoveAt(path.Count - 1);
            path = Pathfinder.FindPath(manager.Party[i].GetComponent<CharacterMove>().OccupiedTile, path[path.Count-1]);
            manager.Party[i].GetComponent<CharacterMove>().Path = path;
            i++;
        }
        
    }
}
