using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private int noOfTriangles = 9;
    [SerializeField] private int noOfCircles = 3;
    [SerializeField] private int noOfSquares = 2;

    [SerializeField] private GameObject triangleIcon; //button
    [SerializeField] private GameObject circleIcon; //button
    [SerializeField] private GameObject squareIcon; //button

    [SerializeField] private TMP_InputField inputField_Triangle;
    [SerializeField] private TMP_InputField inputField_Circle;
    [SerializeField] private TMP_InputField inputField_Square;

    private bool triangleCorrect = false;
    private bool circleCorrect = false;
    private bool squareCorrect = false;

    void Start()
    {
        triangleIcon.GetComponent<Button>().onClick.AddListener(() => TriggerInputField(inputField_Triangle, "Triangle"));
        circleIcon.GetComponent<Button>().onClick.AddListener(() => TriggerInputField(inputField_Circle, "Circle"));
        squareIcon.GetComponent<Button>().onClick.AddListener(() => TriggerInputField(inputField_Square, "Square"));
    }

    void TriggerInputField(TMP_InputField inputField, string shape)
    {
        inputField.ActivateInputField();
        inputField.onEndEdit.AddListener((inputText) =>
        {
            int userInput = 0;
            if (int.TryParse(inputText, out userInput))
            {
                if (shape == "Triangle" && userInput == noOfTriangles)
                {
                    triangleCorrect = true;
                    Debug.Log("Triangle correct!");
                }
                else if (shape == "Circle" && userInput == noOfCircles)
                {
                    circleCorrect = true;
                    Debug.Log("Circle correct!");
                }
                else if (shape == "Square" && userInput == noOfSquares)
                {
                    squareCorrect = true;
                    Debug.Log("Square correct!");
                }
                else
                {
                    Debug.Log($"{shape} incorrect!");
                }

                CheckWin();
            }
            else
            {
                Debug.Log("Invalid input!");
            }
        });
    }

    void CheckWin()
    {
        if (triangleCorrect && circleCorrect && squareCorrect)
        {
            Debug.Log("You won!");
        }
    }
}
