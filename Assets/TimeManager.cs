using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private TimeView view = null;
    [SerializeField]
    private Month startingMonth = Month.January;
    [SerializeField]
    private TimeOfDay startingTime = TimeOfDay.Morning;
    [SerializeField]
    private DayOfWeek startingDay = DayOfWeek.Sunday;

    private TimeTracker timeTracker = null;

    private void Awake()
    {
        timeTracker = new TimeTracker(startingMonth, startingDay, startingTime);
        PrintCurrentTimeInfo();
    }

    private void PrintCurrentTimeInfo()
    {
        view.SetTimeView(timeTracker);
        print($"The current month is {timeTracker.CurrentMonth}");
        print($"The current day is {timeTracker.CurrentDay}");
        print($"The current Time is {timeTracker.CurrentTime}");
    }

    public void OnAdvanceTime()
    {
        timeTracker.AdvanceTime();
        PrintCurrentTimeInfo();
    }

    public void OnAdvanceDay()
    {
        timeTracker.AdvanceDay();
        PrintCurrentTimeInfo();
    }
}
