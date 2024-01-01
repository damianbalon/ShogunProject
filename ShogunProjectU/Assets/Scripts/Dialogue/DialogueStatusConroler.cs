using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStatusConroler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DialogueDisactivate()
    {
        DialogueStatus.IsTrigered = false;
    }

    public void InQuestion()
    {
        DialogueStatus.InQuestion = true;
    }

    public void OutOfQuestion()
    {
        DialogueStatus.InQuestion = false;
    }

}
