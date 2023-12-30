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
    private bool isTrigered;

    private void Awake()
    {
        playerInRange = false;
        isTrigered = false;
        character = GetComponent<CharacterMove>();
    }

    private void LateUpdate()
    {
        playerInRange = PlayerInAdjactedTiles();

        if (playerInRange && Input.GetKeyDown("space") && !isTrigered)
        {
            isTrigered=true;
            menager.StartDialogue(listOfDialogues[0]);
        }else if(playerInRange && Input.GetKeyDown("space"))
        {
            menager.WriteNextLine();
        }

    }

    private bool PlayerInAdjactedTiles()
    {
        List <TacticalTile> adjacted = Pathfinder.GetAdjacentTiles(character.OccupiedTile, 1);
 
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

    public void DialogueDisactivate()
    {
        isTrigered = false;
    }


}