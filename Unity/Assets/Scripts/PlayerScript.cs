using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.UI;

public class PlayerScript : MonoBehaviour
{
    // Get UI Multiple Choice Canvas object
    public GameObject multipleChoiceCanvas;
    public TMP_Text scoreNumber;
    public int score;
    void Start()
    {
        // Hide the Multiple Choice Canvas
        multipleChoiceCanvas.SetActive(false);
        multipleChoiceCanvas.GetComponent<MultipleChoiceMenu>().correctAnswerEvent.AddListener(CorrectAnswer);
        multipleChoiceCanvas.GetComponent<MultipleChoiceMenu>().wrongAnswerEvent.AddListener(WrongAnswer);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        // If the player enters the trigger area
        if (other.gameObject.tag is "TriggerPlane1")
        {
            MultipleChoiceMenu canvasScript = multipleChoiceCanvas.GetComponent<MultipleChoiceMenu>();
            // Show the Multiple Choice Canvas
            other.gameObject.SetActive(false);
            multipleChoiceCanvas.SetActive(true);

            canvasScript.SetQuestion("What is the capital of France?");
            canvasScript.SetAnswers(new string[] {"Paris", "London", "Berlin", "Madrid"});
            canvasScript.SetCorrectAnswer(0);
        }
    }

    public void CorrectAnswer()
    {
        Debug.Log("From player: Correct Answer");
        multipleChoiceCanvas.SetActive(false);
        score++;
        
        scoreNumber.text = "" + score;

    }

    public void WrongAnswer()
    {
        // TODO: Do some instructive shit
        Debug.Log("From player: Wrong Answer");
        multipleChoiceCanvas.SetActive(false);

    }
}
