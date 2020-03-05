using UnityEngine;
using System.Collections;


public enum TypeOfQuestion { International, Domestic, Press }

[CreateAssetMenu(fileName = "Question", menuName = "Question", order = 1)]
public class Question : ScriptableObject
{
	public string objectName = "QuestionObject";
    [Multiline]
	public string question = "";
	public string[] boostingAnswers = new string[]{ };
	public string[] reducingAnswers = new string[]{ };
    public string[] descriptive = new string[] { };
    public bool firstSlotReversed = false;
    [Multiline]
    public string answerBase = "";
    public int requiredAnswers = 0;
    // If negative, means you have to use a negative term to get positive points
    public int firstAnswerDomesticPoints = 0;
    public int firstAnswerInternationalPoints = 0;
    public int secondAnswerDomesticPoints = 0;
    public int secondAnswerInternationalPoints = 0;
    public TypeOfQuestion questionType;
    public string a1;
    public string a2;
    public bool isPositive = false;
}