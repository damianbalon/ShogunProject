using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MUSISZ TO PODPIĄĆ DO OBIEKTU Z KLASĄ PARTYMANAGER
public class PartyMovement : MonoBehaviour
{
    [SerializeField] private Pathfinder pathfinder;
    
    private PartyManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<PartyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTowardsTile(TacticalTile tile) {
        var path = pathfinder.FindPath(manager.Party[0].GetComponent<CharacterMove>().OccupiedTile, tile);
        manager.Party[0].GetComponent<CharacterMove>().Path = path;
        int i = 1, n = manager.Party.Count;
        while(i < n && path.Count > 1) {
            path.RemoveAt(path.Count-1);
            manager.Party[i].GetComponent<CharacterMove>().Path = path;
            i++;
        }
    }
}
