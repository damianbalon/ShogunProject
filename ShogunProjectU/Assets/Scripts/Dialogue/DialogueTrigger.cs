using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private List<TextAsset> listOfDialogues;
    CharacterMove character;
    [SerializeField] DialogueMenager menager;
    [SerializeField] List<GameEvent> dialogEvents;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        character = GetComponent<CharacterMove>();
    }

    private void LateUpdate()
    {
        playerInRange = PlayerInAdjactedTiles();

        if (playerInRange && Input.GetKeyDown("space") && !DialogueStatus.IsTrigered && !DialogueStatus.InQuestion)
        {
            DialogueStatus.IsTrigered = true;
            menager.StartDialogue(listOfDialogues[0], this);
        }
        else if (playerInRange && Input.GetKeyDown("space") && !DialogueStatus.InQuestion)
        {
            menager.WriteNextLine();
        }
    }

    private bool PlayerInAdjactedTiles()
    {
        List<TacticalTile> adjacted = Pathfinder.GetAdjacentTiles(character.OccupiedTile, 1);

        for (int i = 0; i < adjacted.Count; i++)
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

    public void DialogueEvent(int whatEvent)
    {
        dialogEvents[whatEvent].Raise();
    }
}
