using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour
{
    private QuestionMenager menager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }   
    public void Ansver()
    {

        menager.HandleAnsver(this);
    }

    public void SetQuestionMenager(QuestionMenager menager)
    {
        this.menager = menager;
    }
   
}
