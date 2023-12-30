using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
<<<<<<< HEAD
using System.Runtime.CompilerServices;
using System;
=======
>>>>>>> parent of 3a6d56b (Comit)
using System.IO;


public class DialogueMenager : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;

    private string[] lines;
<<<<<<< HEAD
    private int currentLine = -1;
    private int typeofdata = 0 ;



    public void StartDialogue(TextAsset dialogue)
    {
        DialogueActivated.Raise();
        lines = dialogue.text.Split('|');
        WriteNextLine();
=======
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void StartDialogue(TextAsset dialogue)
    {
        lines = dialogue.text.Split('\n');
        WriteDialogue();

>>>>>>> parent of 3a6d56b (Comit)
    }

    private void WriteDialogue()
    {
<<<<<<< HEAD
        
        if (currentLine < lines.Length)
        {
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
     }
=======
        m_Text.text = lines[0];

    }

>>>>>>> parent of 3a6d56b (Comit)
}

