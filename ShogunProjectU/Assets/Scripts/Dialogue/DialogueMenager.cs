using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
<<<<<<< Updated upstream
using System.Runtime.CompilerServices;
using System;
=======
>>>>>>> Stashed changes

public class DialogueMenager : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private GameEvent DialogueActivated;
    [SerializeField] private GameEvent DialogueDisactivated;

    private string[] lines;
    private int currentLine = -1;
<<<<<<< Updated upstream
    private int typeofdata = 0 ;
=======
>>>>>>> Stashed changes

    void Start()
    {

    }

    void Update()
    {

<<<<<<< Updated upstream
=======
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
>>>>>>> Stashed changes
    }

    public void StartDialogue(TextAsset dialogue)
    {
<<<<<<< Updated upstream
        DialogueActivated.Raise();
        lines = dialogue.text.Split('|');
=======

        lines = dialogue.text.Split('\n');
>>>>>>> Stashed changes
        WriteNextLine();
    }

    private void WriteDialogue()
    {
        
        if (currentLine < lines.Length)
        {
<<<<<<< Updated upstream
            switch (typeofdata)
            {
                case 0: //obsu³ga wypisywania imienia;
                    break;
                case 1: m_Text.text = lines[currentLine];
                    break;
                case 2: currentLine = Int16.Parse(lines[currentLine]) -2;
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
=======
            m_Text.text = lines[currentLine];
        }
        else
        {

            m_Text.text = "";
        }
    }

    public void WriteNextLine()
    {
        currentLine++;

        WriteDialogue();
>>>>>>> Stashed changes
    }
}
