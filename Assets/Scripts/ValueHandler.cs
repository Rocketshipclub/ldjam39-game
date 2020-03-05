using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueHandler : MonoBehaviour {

    public float internationalRelations = 0;
    public float domesticRating = 0;
    public Slider internationalSlider;
    public Slider domesticSlider;
    QuestionType type;
    public QuestionType GetQuestionType(QuestionObject obj)
    {
        type = obj.questionType;
        return type;
    }

    public void ChangeValue(float domesticValue, float internationalValue)
    {
        ChangeDomesticValue(domesticValue);
        ChangeInternationalValue(internationalValue);

        MoveSliders();
    }

    public void MoveSliders()
    {
        internationalSlider.value = internationalRelations;
        domesticSlider.value = domesticRating;
    }

    void ChangeInternationalValue(float value)
    {
        internationalRelations += value;
    }

    void ChangeDomesticValue(float value)
    {
        domesticRating += value;
    }
    
}
