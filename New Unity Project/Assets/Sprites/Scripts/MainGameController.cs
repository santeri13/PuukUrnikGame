using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
    [Header("UIstuff")]
    public GameOverScreen Gameoverscreen;
    public BlackScreen blackScreen;



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

    [Header("Prefabs")]
    public GameObject TrashBag;

    private int TimesEaten = 0;
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
    public void Sit()
    {
        blackScreen.fade();
        Sleep += 25;
        if(Sleep > 100)
        {
            Sleep = 100;
        }
        
    }
    public void Eat()
    {
        Hunger += 50;
        if (Hunger > 100)
        {
            Hunger = 100;
        }
        TimesEaten += 1;
        if(TimesEaten == 2)
        {
            TimesEaten = 0;
            GenerateTrash();
        }
    }


    void GenerateTrash()
    {
        Instantiate(TrashBag, new Vector3(Random.Range(10,0), 10, Random.Range(10, 0)), Quaternion.identity);        
    }


    public void SleepOnBed()
    {
        blackScreen.fade();
        Sleep = 100;
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
