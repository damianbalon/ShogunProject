using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Runtime.CompilerServices;
using System;

public class DialogueMenager : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private GameEvent DialogueActivated;
    [SerializeField] private GameEvent DialogueDisactivated;

    private string[] lines;
    private int currentLine = -1;
    private int typeofdata = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    public void StartDialogue(TextAsset dialogue)
    {
        DialogueActivated.Raise();
        lines = dialogue.text.Split('|');
        WriteNextLine();
    }

    private void WriteDialogue()
    {

        if (currentLine < lines.Length)
        {
            switch (typeofdata)
            {
                case 0: //obsu³ga wypisywania imienia;
                    break;
                case 1:
                    m_Text.text = lines[currentLine];
                    break;
                case 2:
                    currentLine = Int16.Parse(lines[currentLine]) - 2;
                    typeofdata = -1;
                    break;
            }
            typeofdata++;
        }
        else
        {
            DialogueDisactivated.Raise();
        }

    }


    public void WriteNextLine()
    {
        for (int i = 0; i < 3; i++)
        {
            currentLine++;

            WriteDialogue();
        }
    }

}
