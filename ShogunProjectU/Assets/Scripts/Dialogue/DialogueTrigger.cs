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

    private bool playerInRange;
    private DialogueStatus dialogueStatus;

    private void Awake()
    {
        playerInRange = false;
        character = GetComponent<CharacterMove>();
        dialogueStatus = new DialogueStatus();
    }

    private void LateUpdate()
    {
        playerInRange = PlayerInAdjactedTiles();

        if (playerInRange && Input.GetKeyDown("space") && !dialogueStatus.IsTrigered && !dialogueStatus.InQuestion)
        {
            dialogueStatus.IsTrigered = true;
            menager.StartDialogue(listOfDialogues[0]);
        }
        else if (playerInRange && Input.GetKeyDown("space") && !dialogueStatus.InQuestion)
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

    public void DialogueDisactivate()
    {
        dialogueStatus.IsTrigered = false;
    }

    public void InQuestion()
    {
        dialogueStatus.InQuestion = true;
    }

    public void OutOfQuestion()
    {
        dialogueStatus.InQuestion = false;
    }
}
