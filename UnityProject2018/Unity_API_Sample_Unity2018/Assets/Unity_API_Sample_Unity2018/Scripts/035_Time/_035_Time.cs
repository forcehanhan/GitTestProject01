/*
 * 时间：
 * 题目：
 * 实现目的：
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// C# _028_Time 改编自Jeff 'PsychicParrot' Murray 的js的timer
/// </summary>
public class _035_Time : MonoBehaviour
{
    private float timeElapsed = 0.0f;
    private float currentTime = 0.0f;
    private float lastTime = 0.0f;
    private float cdTime = 0.0f;
    private float timeScaleFactor = 1.0f;
    private bool isTimerRunning;
    private bool doneCallback;
    private float parseTime;
    private GameObject callback;
    private float aHour;
    private float aMinute;
    private float aSecond;
    private float aMillis;
    private string seconds;
    private string minutes;
    private string hour;
    private string mills;
    private string timeString;
    void Update() {
        timeElapsed = Time.time - lastTime;
        if (isTimerRunning)
        {
            currentTime += timeElapsed * timeScaleFactor;
        }
        lastTime = Time.time;
    }
    public void StartTimer() {
        isTimerRunning = true;
        doneCallback = false;
        lastTime = Time.time;
    }
    public void StopTimer() {
        isTimerRunning = false;
    }
    public void ResetTimer() {
        doneCallback = false;
        timeElapsed = 0.0f;
        lastTime = 0.0f;
        currentTime = 0.0f;
        lastTime = Time.time;
    }
    public void SetCountdownTime(float aTime) {
        cdTime = aTime;
    }
    public void SetCallback(GameObject aRef) {
        callback = aRef;
        doneCallback = false;
    }
    public float GetTime() {
        return currentTime;
    }
    public string GetFormattedTime(int returnType) {
        if (cdTime > 0)
        {
            // if a countdown time has been set, we parse the reverse time value
            parseTime = cdTime - currentTime;
            if (parseTime < 0)
            {
                if (!doneCallback)
                {
                    // SOUND THE ALARM!!!!! WE HIT 0!
                    callback.SendMessage("alarmDone");
                    // set our doneCallback flag so as not to repeat call alarmDone()
                    doneCallback = true;
                }
                parseTime = 0;
            }
        }
        else
        {
            // if no countdown time has been set, we just parse the regular time
            parseTime = currentTime;
        }
        // grab hours
        aHour = parseTime / 3600;
        aHour = aHour % 24;
        // grab minutes
        aMinute = parseTime / 60;
        aMinute = aMinute % 60;
        // grab seconds
        aSecond = parseTime % 60;
        // grab milliseconds
        aMillis = (parseTime * 100) % 100;
        // format string into mm:ss:mm
        seconds = Mathf.Round(aSecond).ToString();
        if (seconds.Length < 2)
            seconds = "0" + seconds;
        minutes = Mathf.Round(aMinute).ToString();
        if (minutes.Length < 2)
            minutes = "0" + minutes;
        hour = Mathf.Round(aHour).ToString();
        if (hour.Length < 2)
            hour = "0" + hour;
        mills = Mathf.Round(aMillis).ToString();
        if (mills.Length < 2)
            mills = "0" + mills;
        switch (returnType)
        {
            case 1:
                timeString = minutes + ":" + seconds + ":" + mills;
                break;
            case 2:
                timeString = minutes + ":" + seconds;
                break;
            default:
                timeString = hour + ":" + minutes + ":" + seconds + ":" + mills;
                break;
        }
        return timeString;
    }
    public float GetHours() {
        if (cdTime > 0)
        {
            // if a countdown time has been set, we parse the reverse time value
            parseTime = cdTime - currentTime;
            if (parseTime < 0)
            {
                parseTime = 0;
            }
        }
        else
        {
            // if no countdown time has been set, we just parse the regular time
            parseTime = currentTime;
        }
        // grab hours
        aHour = parseTime / 3600;
        return aHour;
    }
    public float GetMinutes() {
        if (cdTime > 0)
        {
            // if a countdown time has been set, we parse the reverse time value
            parseTime = cdTime - currentTime;
            if (parseTime < 0)
            {
                parseTime = 0;
            }
        }
        else
        {
            // if no countdown time has been set, we just parse the regular time
            parseTime = currentTime;
        }
        // grab minutes
        aMinute = parseTime / 60;
        aMinute = aMinute % 60;
        return aMinute;
    }
    public float GetSeconds() {
        if (cdTime > 0)
        {
            // if a countdown time has been set, we parse the reverse time value
            parseTime = cdTime - currentTime;
            if (parseTime < 0)
            {
                parseTime = 0;
            }
        }
        else
        {
            // if no countdown time has been set, we just parse the regular time
            parseTime = currentTime;
        }
        // grab seconds
        aSecond = parseTime % 60;
        return aSecond;
    }
    public int getClockTimeHour() {
        int aTime = System.DateTime.Now.Hour;
        return aTime;
    }
    public int getClockTimeMinute() {
        int aTime = System.DateTime.Now.Minute;
        return aTime;
    }
    public int getClockTimeSeconds() {
        int aTime = System.DateTime.Now.Second;
        return aTime;
    }
    public string GetClockFormattedTime(int returnType) {
        int aHour = System.DateTime.Now.Hour;
        int aMinute = System.DateTime.Now.Minute;
        int aSecond = System.DateTime.Now.Second;
        int aMillis = System.DateTime.Now.Millisecond;
        // format string into mm:ss:mm
        seconds = Mathf.Round(aSecond).ToString();
        if (seconds.Length < 2)
            seconds = "0" + seconds;
        minutes = Mathf.Round(aMinute).ToString();
        if (minutes.Length < 2)
            minutes = "0" + minutes;
        hour = Mathf.Round(aHour).ToString();
        if (hour.Length < 2)
            hour = "0" + hour;
        mills = Mathf.Round(aMillis).ToString();
        if (mills.Length < 2)
            mills = "0" + mills;
        if (mills.Length > 2)
            mills = mills.Substring(0, 2);
        switch (returnType)
        {
            case 1:
                timeString = minutes + ":" + seconds + ":" + mills;
                break;
            case 2:
                timeString = minutes + ":" + seconds;
                break;
            default:
                timeString = hour + ":" + minutes + ":" + seconds + ":" + mills;
                break;
        }
        return timeString;
    }
}
