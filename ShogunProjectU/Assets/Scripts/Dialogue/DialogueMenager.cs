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
    [SerializeField] private TMP_Text TextCharacterName;

    [SerializeField] private GameEvent DialogueActivated;
    [SerializeField] private GameEvent DialogueDisactivated;
    [SerializeField] private GameEvent QuestionStart;
    [SerializeField] private GameEvent QuestionEnd;

    [SerializeField] private QuestionMenager QuestionMenager;

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

       
            switch (typeofdata)
            {
                case 0: string id = lines[currentLine];

                    GameObject characterObject = GameObject.Find(id);

                    if (characterObject != null)
                    {
                        Character characterComponent = characterObject.GetComponent<Character>();
                        string name = characterComponent.Charactername;
                        TextCharacterName.text = name;
                    }
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


    public void WriteNextLine()
    {

        for (int i = 0; i < 3; i++)
        {
            currentLine++;

            if (currentLine < lines.Length)
            {
                if (lines[currentLine][0] == '?')
                {

                    QuestionStart.Raise();
                    QuestionMenager.CreateQuestions(m_Text, lines, currentLine);
                    break;
                };

                WriteDialogue();
            }
            else
            {
                DialogueDisactivated.Raise();
            }
        }
    }

    public void AnswerQuestion(int questionSelected)
    {
        currentLine += questionSelected+2;
        currentLine = Int16.Parse(lines[currentLine]) - 2;
        WriteNextLine();
        QuestionEnd.Raise();
    }

}
