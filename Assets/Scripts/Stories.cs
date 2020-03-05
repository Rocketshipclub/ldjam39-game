using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stories : MonoBehaviour  {

    //ARMY COMMENTS
    // PLAYER_NAME + QUOTE + STORY
    string armyHeadline = " OF OUR BOYS";
    string armySecondPositive = "The prime minister uncharacteristically unconfrontational with Rublstani leaders";
    string armySecondNegative = "Rublstan relations cool as the PM says their comments made him ";

    //CORRUPTION
    string corruptionHeadline = "GOVERNMENT IS ";
    string corruptionSecond = "Says the prime minister as accusations of corruption against his government keep mounting";

    //DRUGS
    // PLAYER NAME IN END
    string drugsHeadline = "DRUGS ARE ";
    string drugsSecondPositive = "Legalization of marijuana looking likely in near future";
    string drugsSecondNegative = "Don't have your hopes up for legalization soon, as the prime minister calls the idea ";

    // DROUGHT
    string droughtHeadline = "MÜXICO IS ";
    string droughtSecond = "Not a dime to be given for a suffering neighboring country because the PM saw water at the beach during his holiday.";

    //GAYS
    string gaysHeadline = "I'M ";
    string gaysSecondary = "The PM talks mostly about himself when asked for an opinion on gay rights.";

    //OVERSEAS
    // THE LAST SENTENCE TO BE INSERTED
    string overseasHeadline = "Hunting, fishing or ";
    string overseasSecondaryPositive = "At least he he didn't take Steve with him to the trips abroad.";
    string overseasSecondaryNegative = "The prime minister thinks ";

    //EDUCATION
    string kidsHeadline = " TOPIC EVER";
    string kidsSecondary = "We really don't know what's happening with education";

    //ANIME
    string animeHeadline = "ANIME IS ";
    string animeSecondary = "Groundbreaking press conference clears the prime minister's motives and explains life like never before.";

    //REBELS
    string rebelHeadline = "WE'LL _____ WITH THEM";
    string rebelSecondaryPositive = "People want hardline approach, international community pleased.";
    string rebelSecondaryNegative = "UN appalled by the PM's comments, citizens celebrate 'strong leader'";

    //GLOBAL WARMING
    string globalWarmingHeadline = "";
    string globalWarmingSecondary = "The government thinks this will help with the fight against global warming. God help us all.";

    //FUNDING
    string fundingHeadline = "MAKE DYSFUNCTOPIA ";
    string fundingSecondaryPositive = "It's not going well.";
    string fundingSecondaryNegative = "Well at least he's honest about it.";

    //CEREAL
    string cerealHeadline = "CEREAL = ";
    string cerealSecondary = "People agree that eating ";
    string cerealSecondarySecond = " sounds worse than eating cereal";

    public string MakeCorruptionHeadline(string term1)
    {
        string finalHeadline = corruptionHeadline + "'"+term1+"'";
        return finalHeadline;
    }

    public string MakeCorruptionSecondline()
    {
        return corruptionSecond;
    }

    public string MakeArmyHeadline(string term1)
    {
        string finalHeadline = "'"+ term1 + armyHeadline;
        return finalHeadline;
    }

    public string MakeArmySecondline(bool isPositive, string term1)
    {
        if(isPositive)
        {
            return armySecondPositive;
        }

        else
        {
            string finalSecondline = armySecondNegative + term1;
            return finalSecondline;
        }
    }

    public string MakeDrugsHeadline(string term1)
    {
        string finalHeadline = drugsHeadline + term1;
        return finalHeadline;
    }

    public string MakeDrugsSecondline(bool isPositive, string term1)
    {
        if (isPositive)
        {
            return drugsSecondPositive;
        }

        else
        {
            string finalSecondline = drugsSecondNegative + "'" + term1 + "'";
            return finalSecondline;
        }
    }

    public string MakeDroughtHeadline(string term1)
    {
        string finalHeadline = droughtHeadline + term1;
        return finalHeadline;
    }

    public string MakeDroughtSecondline()
    {
        return droughtSecond;
    }

    public string MakeGaysHeadline(string term1)
    {
        string finalHeadline = gaysHeadline + term1;
        return finalHeadline;
    }

    public string MakeGaysSecondline()
    {
        return gaysSecondary;
    }

    public string MakeOverseasHeadline(string term1)
    {
        string finalHeadline = overseasHeadline + term1;
        return finalHeadline;
    }

    public string MakeOverseasSecondary(bool isPositive, string term1)
    {
        if(isPositive)
        {
            return overseasSecondaryPositive;
        }

        else
        {
            string finalSecondary = overseasSecondaryNegative + term1 + " is an important subject to talk about with foreign leaders.";
            return finalSecondary;
        }
    }

    public string MakeKidsHeadline(string term1)
    {
        string finalHeadline = term1 + kidsHeadline;
        return finalHeadline;
    }

    public string MakeKidsSecondary()
    {
        return kidsSecondary;
    }

    public string MakeAnimeHeadline(string term1)
    {
        string finalHeadline = animeHeadline + term1;
        return finalHeadline;
    }

    public string MakeAnimeSecondary()
    {
        return animeSecondary;
    }

    public string MakeRebelHeadline(string term1)
    {
        string finalHeadline = "WE'll " + term1 + " WITH THEM";
        return finalHeadline;
    }

    public string MakeRebelSecondary(bool isPositive)
    {
        if(isPositive)
        {
            return rebelSecondaryPositive;
        }

        else
        {
            return rebelSecondaryNegative;
        }
    }

    public string MakeGlobalWarmingHeadline(string term1, string term2)
    {
        string finalHeadline = term1 + " AND " + term2;
        return finalHeadline;
    }

    public string MakeGlobalWarmingSecondaryLine()
    {
        return globalWarmingSecondary;
    }

    public string MakeFundingHeadline(string term1)
    {
        string finalHeadline = fundingHeadline + term1 + " AGAIN";
        return finalHeadline;
    }

    public string MakeFundingSecondaryLine(bool isPositive)
    {
        if(isPositive)
        {
            return fundingSecondaryPositive;
        }

        else
        {
            return fundingSecondaryNegative;
        }
    }

    public string MakeCerealHeadline(string term1)
    {
        string finalHeadline = cerealHeadline + term1;
        return finalHeadline;
    }

    public string MakeCerealSecondaryLine(string term1)
    {
        string finalSecondary = cerealSecondary + term1 + cerealSecondarySecond;
        return finalSecondary;
    }

}
