using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameController : MonoBehaviour
{
    [Header("UIstuff")]
    public GameOverScreen Gameoverscreen;
    public BlackScreen blackScreen;
    public Image clockHandTransform;
    public float day;
    public const float REAL_SECONDS_PER_INGAME_DAY = 60f;
    public TextMeshProUGUI DayText;



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
    private int EncounterCounter = 1;
    private int RealDay = 0;
    private float dayNormalized;
    private float rotationDegreesPerDay = 360;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DayText.text = RealDay + "Päev";
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;
        dayNormalized = day % 1f;
        if (day > 1)
        {
            day = 0f;
        }
        clockHandTransform.transform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);
        

        if(dayNormalized * rotationDegreesPerDay == 359)
        {
            RealDay += 1;
        }

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
        
        day += 0.25f;
        if(day > 1f)
        {
            RealDay += 1;
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

    public int GetScene()
    {
        
        return EncounterCounter;
    }
    public void SleepOnBed()
    {
        blackScreen.fade();
        Sleep = 100;
        day += 0.50f;
        print(day);
        if (day > 1f)
        {
            RealDay += 1;
        }
    }
    void UpdateSliders()
    {
        HungerSlider.value = Hunger / MaxHunger;
        SleepSlider.value = Sleep / MaxSleep;
        HeatSlider.value = Heat / MaxHeat;
    }











    public void events(int answer)
    {
        if (EncounterCounter == 1)
        {

            if (answer == 1)
            {
                GameOver();
            }
            else if (answer == 2)
            {
                EncounterCounter = 3;
                //tuleb poeg 1. kord
            }
            else if (answer == 3)
            {

                EncounterCounter = 2;
            }
        }
        else if (EncounterCounter == 2)
        {
            if (answer == 1)
            {
                EncounterCounter = 3;
                //tuelb poeg 1. kord
            }
            else if (answer == 2)
            {
                EncounterCounter = 4;
                //tuleb uuesti tamm
            }
            else if (answer == 3)
            {
                GameOver();
            }
        }
        else if (EncounterCounter == 3)
        {
            //pojaga 1 kord valikud
        }
        else if (EncounterCounter == 4)
        {
            if (answer == 1)
            {
                EncounterCounter = 41;
                //tuelb poeg 1. kord
            }
            else if (answer == 2)
            {
                EncounterCounter = 42;
                //tuleb uuesti tamm
            }
            else if (answer == 3)
            {
                EncounterCounter = 43;
            }
        }
        else if (EncounterCounter == 41 || EncounterCounter == 43)
        {
            if(answer == 1)
            {
                GameOver();
            }
        }
        else if(EncounterCounter == 42)
        {
            if(answer == 1)
            {
                EncounterCounter = 3;
            }
        }
        
    }
    
    public void GameOver()
    {
        Gameoverscreen.Setup();
    }
}
