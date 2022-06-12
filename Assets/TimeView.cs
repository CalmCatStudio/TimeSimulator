using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    [SerializeField]
    private Text
        totalDaysText = null,
        monthText = null,
        dayOfMonthText = null,
        timeOfDayText = null;

    public void SetTimeView(TimeTracker timeTracker)
    {
        var totalDaysString = $"Total: {timeTracker.TotalDays}";
        totalDaysText.text = totalDaysString;
        monthText.text = timeTracker.CurrentMonth.ToString();

        var currentDaysString = $"Day of month: {timeTracker.DayOfMonthCounter}";
        dayOfMonthText.text = currentDaysString;
        timeOfDayText.text = timeTracker.CurrentTime.ToString();
    }
}
