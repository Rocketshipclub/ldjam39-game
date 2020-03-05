using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewspaperStory : MonoBehaviour {

    public QuestionObject featuredStory;
    public Answers answers;
    public Stories stories;
    public bool isPositive = false;

    string mainTitle = "";
    public string MainTitle { get; set; }

    string subTitle = "";
    public string SubTitle { get; set; }

    public Text titleText;
    public Text lowerText;

    public Dictionary<string, string> corruption = new Dictionary<string,string>();
    public Dictionary<string, string> army = new Dictionary<string, string>();
    public Dictionary<string, string> drugs = new Dictionary<string, string>();
    public Dictionary<string, string> kids = new Dictionary<string, string>();
    public Dictionary<string, string> gays = new Dictionary<string, string>();
    public Dictionary<string, string> globalwarming = new Dictionary<string, string>();
    public Dictionary<string, string> drought = new Dictionary<string, string>();
    public Dictionary<string, string> overseas = new Dictionary<string, string>();
    public Dictionary<string, string> anime = new Dictionary<string, string>();
    public Dictionary<string, string> rebels = new Dictionary<string, string>();
    public Dictionary<string, string> funding = new Dictionary<string, string>();
    public Dictionary<string, string> cereal = new Dictionary<string, string>();

    //CORRUPTION
    //ARMY
    //DRUGS
    //DROUGHT
    //GAYS
    //OVERSEAS
    //EDUCATION
    //ANIME
    //REBELS
    //GLOBALWARMING
    //FUNDING
    //CEREAL
    public List<bool> positives = new List<bool>()
    {
        false, false, false, false, false, false, false, false, false, false, false, false
    };

    public void FormStory(int round)
    {
        switch(round)
        {
            case 1:
                featuredStory = answers.questionObjects[Random.Range(0, 3)];
                break;
            case 2:
                featuredStory = answers.questionObjects[Random.Range(3, 6)];
                break;
            case 3:
                featuredStory = answers.questionObjects[Random.Range(6, 9)];
                break;
            case 4:
                featuredStory = answers.questionObjects[Random.Range(9, 12)];
                break;
            case 5:
                mainTitle = "THANKS FOR PLAYING";
                subTitle = "REMEMBER: Friends don't let friends get into politics";
                break;
        }

        string title = featuredStory.objectName;

        switch(title)
        {
            case "Corruption":
                foreach (var k in corruption)
                {
                    mainTitle = stories.MakeCorruptionHeadline(k.Key);
                    break;
                }
                subTitle = stories.MakeCorruptionSecondline();
                break;
            case "Army":
                foreach(var k in army)
                {
                    mainTitle = stories.MakeArmyHeadline(k.Key);
                    if (positives[1])
                    {
                        subTitle = stories.MakeArmySecondline(true, k.Value);
                    }
                    else
                    {
                        subTitle = stories.MakeArmySecondline(false, k.Value);
                    }
                    break;
                }
                break;
            case "Drugs":
                foreach(var k in drugs)
                {
                    mainTitle = stories.MakeDrugsHeadline(k.Key);
                    if (positives[2])
                    {
                        subTitle = stories.MakeDrugsSecondline(true, k.Value);
                    }
                    else
                    {
                        subTitle = stories.MakeDrugsSecondline(false, k.Value);
                    }
                    break;
                }
                
                break;
            case "Drought":
                foreach(var k in drought)
                {
                    mainTitle = stories.MakeDroughtHeadline(k.Key);
                    break;
                }
                subTitle = stories.MakeDroughtSecondline();
                break;
            case "Gays":
                foreach(var k in gays)
                {
                    mainTitle = stories.MakeGaysHeadline(k.Key);
                    break;
                }
                
                subTitle = stories.MakeGaysSecondline();
                break;
            case "Overseas":
                foreach(var k in overseas)
                {
                    mainTitle = stories.MakeOverseasHeadline(k.Value);
                    if (positives[5])
                    {
                        subTitle = stories.MakeOverseasSecondary(true, k.Key);
                    }
                    else
                    {
                        subTitle = stories.MakeOverseasSecondary(false, k.Value);
                    }
                    break;
                }
                break;
            case "Education":
                foreach(var k in kids)
                {
                    mainTitle = stories.MakeKidsHeadline(k.Key);
                    break;
                }
                subTitle = stories.MakeKidsSecondary();
                break;
            case "Anime":
                foreach(var k in anime)
                {
                    mainTitle = stories.MakeAnimeHeadline(k.Key);
                    break;
                }
                subTitle = stories.MakeAnimeSecondary();
                break;
            case "Rebels":
                foreach(var k in rebels)
                {
                    mainTitle = stories.MakeRebelHeadline(k.Key);
                    if (positives[8])
                    {
                        subTitle = stories.MakeRebelSecondary(true);
                    }
                    else
                    {
                        subTitle = stories.MakeRebelSecondary(false);
                    }
                    break;
                }
                break;
            case "GlobalWarming":
                foreach(var k in globalwarming)
                {
                    mainTitle = stories.MakeGlobalWarmingHeadline(k.Key, k.Value);
                    break;
                }
                subTitle = stories.MakeGlobalWarmingSecondaryLine();
                break;
            case "Funding":
                foreach(var k in funding)
                {
                    mainTitle = stories.MakeFundingHeadline(k.Value);
                    if (positives[10])
                    {
                        subTitle = stories.MakeFundingSecondaryLine(true);
                    }
                    else
                    {
                        subTitle = stories.MakeFundingSecondaryLine(false);
                    }
                    break;
                }
                break;
            case "Cereal":
                foreach(var k in cereal)
                {
                    mainTitle = stories.MakeCerealHeadline(k.Key);
                    subTitle = stories.MakeCerealSecondaryLine(k.Key);
                    break;
                }
                break;
        }

        titleText.text = mainTitle;
        lowerText.text = subTitle;

    }

    public void SaveTerms(QuestionObject question, string first, string second)
    {
        switch(question.objectName)
        {
            case "Corruption":
                corruption.Clear();
                corruption.Add(first, second);
                break;
            case "Army":
                army.Clear();
                army.Add(first, second);
                break;
            case "Drugs":
                drugs.Clear();
                drugs.Add(first, second);
                break;
            case "Kids":
                kids.Clear();
                kids.Add(first, second);
                break;
            case "Gays":
                gays.Clear();
                gays.Add(first, second);
                break;
            case "GlobalWarming":
                globalwarming.Clear();
                globalwarming.Add(first, second);
                break;
            case "Drought":
                drought.Clear();
                drought.Add(first, second);
                break;
            case "Overseas":
                overseas.Clear();
                overseas.Add(first, second);
                break;
            case "Anime":
                anime.Clear();
                anime.Add(first, second);
                break;
            case "Rebels":
                rebels.Clear();
                rebels.Add(first, second);
                break;
            case "Funding":
                funding.Clear();
                funding.Add(first, second);
                break;
            case "Cereal":
                cereal.Clear();
                cereal.Add(first, second);
                break;
        }
    }

    public void GameOver()
    {
        titleText.text = "THANKS FOR PLAYING";
        lowerText.text = "REMEMBER: Friends don't let friends get into politics.";
        Invoke("EndGame", 5);
    }

    public void EndGame()
    {
        Application.Quit();
    }

}
