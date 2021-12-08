using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
    public GameOverScreen Gameoverscreen;



    [Header("PlayerHunger")]
    public float MaxHunger = 100f;
    public float Hunger = 0f;
    public Slider HungerSlider;
    public float HungerOT = 0.8f;
    [Header("PlayerSleep")]
    public float MaxSleep = 100f;
    public float Sleep = 0f;
    public Slider SleepSlider;
    public float SleepOT = 0.2f;
    [Header("PlayerHeat")]
    public float MaxHeat = 100f;
    public float Heat = 0f;
    public Slider HeatSlider;
    public float HeatOT = 0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hunger = Hunger - HungerOT * Time.deltaTime;
        Sleep = Sleep - SleepOT * Time.deltaTime;
        Heat = Heat - HeatOT * Time.deltaTime;
        if(Sleep < 0f || Hunger < 0f || Sleep < 0f)
        {
            GameOver();
        }
        UpdateSliders();
    }
    void UpdateSliders()
    {
        HungerSlider.value = Hunger / MaxHunger;
        SleepSlider.value = Sleep / MaxSleep;
        HeatSlider.value = Heat / MaxHeat;
    }
    void GameOver()
    {
        Gameoverscreen.Setup();
    }
}
