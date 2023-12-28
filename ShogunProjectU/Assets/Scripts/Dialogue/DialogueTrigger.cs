using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{


    [SerializeField]
    private GameEvent ActiveDialogue;

    CharacterMove character;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
    }

    private void Update()
    {
        playerInRange = PlayerInAdjactedTiles();

        if (playerInRange && Input.GetKeyDown("space"))
        {
            if (character)
            {
                ActiveDialogue.Raise();
            }
        }

        playerInRange = false;

    }

    private bool PlayerInAdjactedTiles()
    {
        List <TacticalTile> adjacted = character.Pathfinder.GetAdjacentTiles(character.OccupiedTile, 1);
        
        for(int i=0; i< adjacted.Count; i++)
        {
            if (adjacted[i].OccupyingObject != null)
            {


                if (adjacted[i].OccupyingObject.tag == "Player")
                {
                    return true;
                }
            }
        }
        return false;
    }


}