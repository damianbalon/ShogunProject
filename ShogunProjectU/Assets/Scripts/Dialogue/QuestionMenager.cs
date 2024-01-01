using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestionMenager : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] private DialogueMenager dialogueMenager;

    private int howManyQuestins;
    List<GameObject> buttons;

    // Start is called before the first frame update
    void Start()
    {
        howManyQuestins = 0;
        buttons = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateQuestions(TMP_Text m_Text, string[] lines, int curentLine)
    {
        Transform panelTransform = m_Text.GetComponentInParent<Transform>();

        while (true)
        {
            if (lines[curentLine][0] == '?')
            {
                float shift = 40 + (-40 * howManyQuestins);
                Vector3 localPosition = new Vector3(0.0f, shift, 0.0f);
                Quaternion qua = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

                // Convert local position to global position using TransformPoint
                Vector3 globalPosition = panelTransform.TransformPoint(localPosition);

                buttons.Add(Instantiate(button, globalPosition, qua, panelTransform));

                // Remove the question mark from the beginning of the text
                string questionText = lines[curentLine].Substring(1);

                TMP_Text Textone = buttons[howManyQuestins].GetComponentInChildren<TMP_Text>();
                Textone.text = questionText;

                ButtonControler buttonmengaer = buttons[howManyQuestins].GetComponent<ButtonControler>();
                buttonmengaer.SetQuestionMenager(this);

                howManyQuestins++;
                curentLine += 2;

            }
            else
            {
                break;
            }
        }
    }

    public void DestroyQuestions()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i]);
        }
        buttons.Clear();
    }

    public void HandleAnsver(ButtonControler buttoncontroller)
    {
        GameObject selectedButton = buttoncontroller.gameObject;

        int index = buttons.FindIndex(0, howManyQuestins, x => x == selectedButton);

        if (index != -1)
        {
            dialogueMenager.AnswerQuestion(index);
        }
    }
}
