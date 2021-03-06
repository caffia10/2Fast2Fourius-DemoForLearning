﻿using Assets.Source.DesignPattern;
using UnityEngine;

public class RouteEngine : SingletonMonoBehaviour<RouteEngine>
{
    public GameObject ContainerGO;
    private GameObject[] routesGO;

    public float Speed;
    public bool StartGame;

    private bool gameOver;
    public bool IsGameOver => gameOver;

    private int countRoute = 0;
    private int numberSelectorRoad;

    private GameObject previousRoad;
    private GameObject laterRoad;

    private float sizeOfRoute;

    private Vector3 limitScreen;

    private bool OutScreen;

    public Camera Camera;

    private GameObject carGo;
    private GameObject audioFxGo;
    private AudioFx audioFxComp;
    public GameObject BgFinal;

    void Start()
    {
        BeginPlay();
    }

    private void BeginPlay()
    {
        BgFinal.SetActive(false);

        audioFxComp = AudioFx.Instance;
        carGo = Car.Instance.gameObject;

        SpeedRouteEngine();
        MeasureScreen();
        FindRoute();
    }

    private void SpeedRouteEngine()
    {
        Speed = 18;
    }

    private void FindRoute()
    {
        routesGO = GameObject.FindGameObjectsWithTag("RouteTag");
        for (int i = 0; i < routesGO.Length; i++)
        {
            routesGO[i].gameObject.transform.parent = ContainerGO.transform;
            routesGO[i].gameObject.SetActive(false);
            routesGO[i].gameObject.name = "RouteOff_" + i;
        }

        CreateRoute();
    }

    private void CreateRoute()
    {
        countRoute ++;
        numberSelectorRoad = Random.Range(0, routesGO.Length);
        GameObject route = Instantiate(routesGO[numberSelectorRoad]);
        route.SetActive(true);
        route.name = "Route_" + countRoute;
        route.transform.parent = gameObject.transform;
        PositionRoad();
        OutScreen = false;
    }

    private void PositionRoad()
    {
        previousRoad = GameObject.Find("Route_" + (countRoute -1));
        laterRoad = GameObject.Find("Route_" + countRoute);
        MeasureRoad();
        laterRoad.transform.position = new Vector3(previousRoad.transform.position.x,
                                                   previousRoad.transform.position.y + sizeOfRoute,
                                                   0);
    }
        
    private void MeasureRoad()
    {
        for (int i = 0; i < previousRoad.transform.childCount; i++)
        {
            sizeOfRoute += GetSizeOfRoadByIndex(i);
        }
    }

    private float GetSizeOfRoadByIndex(int index)
    {
        GameObject roadGO = previousRoad.transform.GetChild(index).gameObject;

        return roadGO.GetComponent<Road>() != null? roadGO.GetComponent<SpriteRenderer>().bounds.size.y : 0;
    }

    private void MeasureScreen()
    {
        limitScreen = new Vector3(0, Camera.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f, 0);
    }

    void Update()
    {
        if (StartGame && !gameOver)
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);

            if (OutScreen == false && (previousRoad.transform.position.y + sizeOfRoute) < limitScreen.y)
            {
                OutScreen = true;
                DestroyRoute();
            }
        }
    }

    private void DestroyRoute()
    {
        Destroy(previousRoad);
        sizeOfRoute = 0;
        previousRoad = null;
        CreateRoute();
    }

    public void GameOverState()
    {
        gameOver = true;
        carGo.GetComponent<AudioSource>().Stop();
        audioFxComp.FXSoundGameOver();
        BgFinal.SetActive(true);
    }
}
