using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueMenager : MonoBehaviour
{
    private string[] lines;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void StartDialogue(TMP_Text dialogue)
    {
        lines = dialogue.text.Split('\n');
        WriteDialogue();

    }

    private void WriteDialogue()
    {


    }

}
