using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DayOfWeek
{
    Sunday,
    Monday,
    Tuesday,
    Wednsday,
    Thursday,
    Friday,
    Saturday
}

public enum TimeOfDay
{
    /* I included a Dusk, and Dawn state. 
       Staying up till Dusk makes you wake up at Noon the next day, and Dawn wakes at Afternoon.
       Remove them if your game doesn't need them.*/
    Morning,
    Noon,
    Afternoon,
    Evening,
    Night,
    Dusk, 
    Dawn
}

public enum Month
{
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}

public class TimeTracker
{
    private DayOfWeek currentDay;
    public DayOfWeek CurrentDay => currentDay;

    private TimeOfDay currentTime;
    public TimeOfDay CurrentTime => currentTime;

    private Month currentMonth;
    public Month CurrentMonth => currentMonth;

    // Months will all be 30 days long for simplicity. I may change this in the future.
    private int dayOfMonthCounter = 1;
    public int DayOfMonthCounter => dayOfMonthCounter;

    private int totalDays = 1;
    public int TotalDays => totalDays;

    private int totalYears = 0;
    public int TotalYears => totalYears;

    public TimeTracker(Month startMonth, DayOfWeek startDay, TimeOfDay startTime)
    {
        currentDay = startDay;
        currentTime = startTime;
        currentMonth = startMonth;
    }

    public void AdvanceTime()
    {
        switch (currentTime)
        {
            case TimeOfDay.Morning:
                currentTime = TimeOfDay.Noon;
                break;
            case TimeOfDay.Noon:
                currentTime = TimeOfDay.Afternoon;
                break;
            case TimeOfDay.Afternoon:
                currentTime = TimeOfDay.Evening;
                break;
            case TimeOfDay.Evening:
                currentTime = TimeOfDay.Night;
                break;
            case TimeOfDay.Night:
                currentTime = TimeOfDay.Dusk;
                break;
            case TimeOfDay.Dusk:
                currentTime = TimeOfDay.Dawn;
                break;
            case TimeOfDay.Dawn:
                AdvanceDay();
                break;
            default:
                Debug.LogError("Current Time of day not defined.");
                break;
        }
    }

    public void AdvanceDay()
    {
        switch (currentDay)
        {
            case DayOfWeek.Sunday:
                SetDayOfWeek(DayOfWeek.Monday);
                break;
            case DayOfWeek.Monday:
                SetDayOfWeek(DayOfWeek.Tuesday);
                break;
            case DayOfWeek.Tuesday:
                SetDayOfWeek(DayOfWeek.Wednsday);
                break;
            case DayOfWeek.Wednsday:
                SetDayOfWeek(DayOfWeek.Thursday);
                break;
            case DayOfWeek.Thursday:
                SetDayOfWeek(DayOfWeek.Friday);
                break;
            case DayOfWeek.Friday:
                SetDayOfWeek(DayOfWeek.Saturday);
                break;
            case DayOfWeek.Saturday:
                SetDayOfWeek(DayOfWeek.Sunday);
                break;
            default:
                Debug.LogError("Current Day not defined.");
                break;
        }
        SetTimeForNewDay();
        dayOfMonthCounter++;
        totalDays++;
        SetMonth();
    }

    private void SetDayOfWeek(DayOfWeek newDay)
    {
        currentDay = newDay;
    }

    private void SetMonth()
    {
        if (dayOfMonthCounter > 30)
        {
            dayOfMonthCounter = 0;

            switch (currentMonth)
            {
                case Month.January:
                    currentMonth = Month.February;
                    break;
                case Month.February:
                    currentMonth = Month.March;
                    break;                    
                case Month.March:
                    currentMonth = Month.April;
                    break;
                case Month.April:
                    currentMonth = Month.May;
                    break;
                case Month.May:
                    currentMonth = Month.June;
                    break;
                case Month.June:
                    currentMonth = Month.July;
                    break;
                case Month.July:
                    currentMonth = Month.August;
                    break;
                case Month.August:
                    currentMonth = Month.September;
                    break;
                case Month.September:
                    currentMonth = Month.October;
                    break;
                case Month.October:
                    currentMonth = Month.November;
                    break;
                case Month.November:
                    currentMonth = Month.December;
                    break;
                case Month.December:
                    currentMonth = Month.January;
                    totalYears++;
                    break;
            }
        }
    }

    private void SetTimeForNewDay()
    {
        switch (currentTime)
        {
            case TimeOfDay.Dusk:
                currentTime = TimeOfDay.Noon;
                break;
            case TimeOfDay.Dawn:
                currentTime = TimeOfDay.Afternoon;
                break;
            default:
                currentTime = TimeOfDay.Morning;
                break;
        }
    }
}
