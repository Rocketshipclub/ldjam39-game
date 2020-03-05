using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour {

    public List<Text> answers = new List<Text>();
    public List<Button> buttons = new List<Button>();
    public QuestionObject selectedQuestion;
    string descriptive = "";
    public string first = "";
    string firstPreviously;
    public string second = "";
    public Text completeAnswer;
    public Text question;
    public ValueHandler handler;
    int clickCounter = 0;
    int round = 1;
    Helpers helper = new Helpers();
    public List<QuestionObject> questionObjects = new List<QuestionObject>();
    public Button nextQuestion;
    int currentQuestion = 1;
    public Canvas startGameCanvas;
    public Canvas mainCanvas;
    public Canvas newspaperCanvas;
    public NewspaperStory story;
    public Image reporterQuestion;
    public Image answerImage;

    public List<Sprite> presidents = new List<Sprite>();
    public Image president;

    public string endingSpeech = "And that concludes the press conference for today, I thank you for your time.";
    
    public void StartGame(int id)
    {
        president.sprite = presidents[id];
        selectedQuestion = questionObjects[0];
        clickCounter = selectedQuestion.requiredAnswers;
        question.text = selectedQuestion.question;
        startGameCanvas.enabled = false;
        mainCanvas.enabled = true;
    }
    
    public void LoadAnswer()
    {
        reporterQuestion.gameObject.SetActive(false);
        answerImage.gameObject.SetActive(true);
        SetAnswers();
    }

    public void PickAnswers(int buttonId)
    {
        ProcessAnswers(buttonId);
        buttons[buttonId].interactable = false;
        clickCounter--;
        if(clickCounter == 0)
        {
            Proceed(buttonId);
        }
    }

    void Proceed(int buttonId)
    {
        CheckAnswerValue(first, second);
        if (currentQuestion % 3 == 0)
        {
            Invoke("DoEndingSpeech", 5);
        }
        else
        {
            handler.GetQuestionType(selectedQuestion);
            if (selectedQuestion != questionObjects[questionObjects.Count - 1])
            {
                for (int i = 0; i < questionObjects.Count; i++)
                {
                    if (questionObjects[i] == selectedQuestion)
                    {
                        selectedQuestion = questionObjects[i + 1];
                        break;
                    }
                }
            }

            nextQuestion.gameObject.SetActive(true);
            currentQuestion++;
        }
    }

    public void SetAnswers()
    {
        foreach(Button b in buttons)
        {
            b.gameObject.SetActive(true);
        }
        List<string> selectedAnswers = randomizeAnswer();
        foreach (Text t in answers)
        {
            foreach (string s in selectedAnswers)
            {
                t.text = s;
                selectedAnswers.Remove(s);
                break;
            }
        }
        completeAnswer.text = selectedQuestion.answerBase;
        if(selectedQuestion.descriptive.Length > 0)
        {
            descriptive = selectedQuestion.descriptive[Random.Range(0, selectedQuestion.descriptive.Length - 1)];
            completeAnswer.text = helper.ReplaceFirst(completeAnswer.text, "*****", descriptive);
            WordRandomizer();
        }
    }

    // Next question buttons activates this method
    public void ResetView()
    {
        nextQuestion.gameObject.SetActive(false);
        SetAnswers();
        foreach(Button b in buttons)
        {
            b.interactable = true;
            b.gameObject.SetActive(false);
        }
        clickCounter = selectedQuestion.requiredAnswers;
        question.text = selectedQuestion.question;
        reporterQuestion.gameObject.SetActive(true);
        answerImage.gameObject.SetActive(false);
    }

    List<string> randomizeAnswer()
    {
        List<string> _answers = new List<string>();
        foreach(string s in selectedQuestion.boostingAnswers)
        {
            _answers.Add(s);
        }
        foreach (string t in selectedQuestion.reducingAnswers)
        {
            _answers.Add(t);
        }

        List<string> selected = new List<string>();

        for (int i = 0; i < answers.Count; i++)
        {
            string r = _answers[Random.Range(0, _answers.Count)];
            while (selected.Contains(r))
            {
                r = _answers[Random.Range(0, _answers.Count)];
            }
            selected.Add(r);
        }
        return selected;
    }

    string ProcessAnswers(int buttonId)
    {
        completeAnswer.text = helper.ReplaceFirst(completeAnswer.text, "_____", answers[buttonId].text);
        
        if (first == firstPreviously || first == "")
        {
            first = answers[buttonId].text;
            return first;
        }
        second = answers[buttonId].text;
        return second;
    }

    void CheckAnswerValue(string first, string second)
    {
        float internationalValue = 0;
        float domesticValue = 0;

        story.SaveTerms(selectedQuestion, first, second);

        foreach (string a in selectedQuestion.boostingAnswers)
        {
            if (a == first)
            {
                domesticValue += selectedQuestion.firstAnswerDomesticPoints;
                internationalValue += selectedQuestion.firstAnswerInternationalPoints;
            }

            else if(a == second)
            {
                domesticValue += selectedQuestion.secondAnswerDomesticPoints;
                internationalValue += selectedQuestion.secondAnswerInternationalPoints;
            }
        }

        foreach (string a in selectedQuestion.reducingAnswers)
        {
            if (a == first)
            {
                domesticValue -= selectedQuestion.firstAnswerDomesticPoints;
                internationalValue -= selectedQuestion.firstAnswerInternationalPoints;
            }

            else if (a == second)
            {
                domesticValue -= selectedQuestion.secondAnswerDomesticPoints;
                internationalValue -= selectedQuestion.secondAnswerInternationalPoints;
            }
        }

        if(selectedQuestion.questionType == QuestionType.Domestic)
        {
            if(domesticValue >= 0)
            {
                if(selectedQuestion.objectName == "Army")
                {
                    story.positives[1] = true;
                }
                else if(selectedQuestion.objectName == "Drugs")
                {
                    story.positives[2] = true;
                }
                else if (selectedQuestion.objectName == "Overseas")
                {
                    story.positives[5] = true;
                }
                else if (selectedQuestion.objectName == "Rebels")
                {
                    story.positives[8] = true;
                }
                else if (selectedQuestion.objectName == "Funding")
                {
                    story.positives[10] = true;
                }
            }
        }

        else
        {
            if(internationalValue >= 0)
            {
                selectedQuestion.isPositive = true;
            }

            else
            {
                selectedQuestion.isPositive = false;
            }
        }
        firstPreviously = first;
        handler.ChangeValue(domesticValue, internationalValue);
    }

    void WordRandomizer()
    {
        completeAnswer.text = helper.ReplaceFirst(completeAnswer.text, descriptive, selectedQuestion.descriptive[Random.Range(0, selectedQuestion.descriptive.Length - 1)]);
    }

    void DoEndingSpeech()
    {
        completeAnswer.text = endingSpeech;
        Invoke("ShowNewspapers", 2);
    }

    void ShowNewspapers()
    {
        mainCanvas.enabled = false;
        newspaperCanvas.enabled = true;
        story.FormStory(round);
        round++;
    }

    public void StartNextPressConference()
    {
        if(round < 5)
        {
            newspaperCanvas.enabled = false;
            mainCanvas.enabled = true;
            nextQuestion.gameObject.SetActive(false);
            foreach (Button b in buttons)
            {
                b.interactable = true;
                b.gameObject.SetActive(false);
            }
            clickCounter = selectedQuestion.requiredAnswers;
            question.text = selectedQuestion.question;
            reporterQuestion.gameObject.SetActive(true);
            answerImage.gameObject.SetActive(false);
            currentQuestion++;
            if (selectedQuestion != questionObjects[questionObjects.Count - 1])
            {
                for (int i = 0; i < questionObjects.Count; i++)
                {
                    if (questionObjects[i] == selectedQuestion)
                    {
                        selectedQuestion = questionObjects[i + 1];
                        break;
                    }
                }
            }
            clickCounter = selectedQuestion.requiredAnswers;
            question.text = selectedQuestion.question;
        }
        
        else
        {
            story.GameOver();
        }

    }
    
}
