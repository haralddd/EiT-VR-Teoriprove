using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MultipleChoiceMenu : MonoBehaviour
{
    public Button toggleButton;
    public Button[] answerButtons;
    public GameObject panel;
    public TMP_Text questionText;
    public int correctAnswer;
    public UnityEvent wrongAnswerEvent;
    public UnityEvent correctAnswerEvent;

    void Start()
    {
        if (wrongAnswerEvent == null)
            wrongAnswerEvent = new UnityEvent();
        if (correctAnswerEvent == null)
            correctAnswerEvent = new UnityEvent();
        toggleButton.onClick.AddListener(TogglePanelVisibility);
        foreach (Button button in answerButtons) {
            button.onClick.AddListener(CheckAnswer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TogglePanelVisibility()
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void SetQuestion(string question)
    {
        questionText.text = question;
    }

    public void SetAnswers(string[] answers)
    {
        if (answers.Length != 4)
        {
            Debug.LogError("Answers array must have 4 elements");
            return;
        }
        for (int i = 0; i < 4; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = answers[i];
        }
    }

    public void SetCorrectAnswer(int correct)
    {
        correctAnswer = correct;
    }

    public void CheckAnswer(int answer)
    {
        Debug.Log("Clicked: " + answer + "\t Correct: " + correctAnswer);
        if (answer == correctAnswer)
        {
            correctAnswerEvent.Invoke();
        }
        else
        {
            wrongAnswerEvent.Invoke();
        }
    }
}
