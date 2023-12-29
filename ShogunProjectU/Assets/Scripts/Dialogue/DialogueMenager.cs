using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class DialogueMenager : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;

    private string[] lines;
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

    }

    private void WriteDialogue()
    {
        m_Text.text = lines[0];

    }

}
