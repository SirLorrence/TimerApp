using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeCounter : MonoBehaviour {

    float displayTime;
    float seconds = 0;
    float milliSeconds = 0;
    bool activeTimer;
    bool displayGuide = false;

    public Text currentTime;
    public Text previousTime;
    public Text Guide;
    public Sprite[] buttonImage;
    public Image currentButtonImage;
    void Start() => TimerReset();

    void Update() {
        Timer();

#if UNITY_STANDALONE 
        if (Input.GetKeyDown(KeyCode.Space)) TimerAction();
        if (Input.GetKeyDown(KeyCode.R)) TimerReset();
        displayGuide = true;
#endif
    }

    #region Actions
    //Switches action between start and pause
    public void TimerAction() {
        if (activeTimer) {
            activeTimer = false;
            currentButtonImage.sprite = buttonImage[0];
        }
        else {
            activeTimer = true;
            currentButtonImage.sprite = buttonImage[1];
        }
    }
    public void TimerReset() {
        currentButtonImage.sprite = buttonImage[0];
        activeTimer = false;
        previousTime.text = currentTime.text;
        seconds = 0;
        milliSeconds = 0;
        displayTime = 0;
        currentTime.text = string.Format("{0:00}:{1:000}", seconds, milliSeconds);
    }
    #endregion
    private void Timer() {
        if (activeTimer) {
            displayTime += Time.deltaTime;
            seconds = Mathf.FloorToInt(displayTime);
            milliSeconds = (displayTime % 1) * 1000;
            currentTime.text = string.Format("{0:00}:{1:000}", seconds, milliSeconds);
        }
    }

}
