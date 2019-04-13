using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour
{
    private float distance;
    private RouteEngine routeEngineComp;

    private float timeValue;
    public float TimeValue
    {
        get
        {
            return timeValue;
        }

        set
        {
            timeValue = value;

            if (timeValue < 0.0F)
            {
                timeValue = 0.0F;
            }
        }
    }
    
    public Text TimeText;
    public Text DistanceText;
    public Text FinalDistanceText;

    void Start()
    {
        routeEngineComp = this.GetComponentFromUniqueInstance<RouteEngine>();

        TimeText.text = "2:00";
        DistanceText.text = "0";

        TimeValue = 120;
    }

    void Update()
    {
        if (routeEngineComp.StartGame && !routeEngineComp.IsGameOver)
        {
            CalculateDistanceAndTime();
        }

        if  (TimeValue <= 0 && !routeEngineComp.IsGameOver)
        {
            routeEngineComp.GameOverState();
            FinalDistanceText.text = $"{(int) distance} MTS";
        }
    }

    private void CalculateDistanceAndTime()
    {
        distance += Time.deltaTime * routeEngineComp.Speed;

        DistanceText.text = ((int)distance).ToString();

        TimeValue -= Time.deltaTime;
        int minutes = (int)TimeValue / 60;
        int seconds = (int)TimeValue % 60;

        TimeText.text = $"{minutes}:{seconds.ToString().PadLeft(2, '0')}";
    }
}
