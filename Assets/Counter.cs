using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Net.Mime;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Counter : MonoBehaviour
{

float displayTime;
    float seconds=0;
    float milliSeconds=0;
    bool activeTimer;

    public Text displayText;
    public Text previousTime;
    public Sprite[] buttonImage;
    public Image currentButtonImage;
    void Start()
    {
        Reset();
    }

    void Update() {
        if(activeTimer){
        displayTime += Time.deltaTime;
        seconds = Mathf.FloorToInt(displayTime);
        milliSeconds = (displayTime % 1) * 1000;
        displayText.text = string.Format("{0:00}:{1:000}",seconds,milliSeconds);
         } 
    }

    public void TimerAction() {
        if(activeTimer){
            activeTimer = false;
            currentButtonImage.sprite = buttonImage[0];
        }
        else{
        activeTimer = true;
        currentButtonImage.sprite = buttonImage[1]; 
        }
    }
    public void Reset(){
        currentButtonImage.sprite = buttonImage[0];
        activeTimer = false;
        previousTime.text = displayText.text;
        seconds=0;
        milliSeconds=0;
        displayText.text = string.Format("{0:00}:{1:000}",seconds,milliSeconds);
    }
}
