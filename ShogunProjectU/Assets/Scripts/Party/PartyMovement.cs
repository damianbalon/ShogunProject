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
        var path = Pathfinder.FindPath(manager.Party[0].GetComponent<CharacterMove>().originTile, tile);
        //Debug.Log("Długość drogi: " + path.Count);
        manager.Party[0].GetComponent<CharacterMove>().Path = path;
        int n = manager.Party.Count, i = 1;
        path.Insert(0, manager.Party[0].GetComponent<CharacterMove>().originTile);
        while(i < n && path.Count > 1) {
            path.RemoveAt(path.Count - 1);
            path = Pathfinder.FindPath(manager.Party[i].GetComponent<CharacterMove>().originTile, path[path.Count-1]);
            manager.Party[i].GetComponent<CharacterMove>().Path = path;
            path.Insert(0, manager.Party[i].GetComponent<CharacterMove>().originTile);
            i++;
        }
        Debug.Log(i);
    }
}
