using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<TextAsset> listOfDialogues;

    CharacterMove character;
    [SerializeField]  DialogueMenager menager; 

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        character = GetComponent<CharacterMove>();
    }

    private void  Update()
    {
        playerInRange = PlayerInAdjactedTiles();

        if (playerInRange && Input.GetKeyDown("space"))
        {

            menager.StartDialogue(listOfDialogues[0]);
        }

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