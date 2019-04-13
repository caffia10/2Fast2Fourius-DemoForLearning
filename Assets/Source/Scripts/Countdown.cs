using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public RouteEngine RouteEngineComp;
    public Sprite[] numbers;
    public SpriteRenderer SpriteRendererComp;

    public GameObject CarControllerGo;
    public GameObject CarGo;

    public GameObject CountNumbersGO;

    void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        RouteEngineComp = this.GetComponentFromUniqueInstance<RouteEngine>();

        CountNumbersGO = GameObject.Find("CountNumbers");
        SpriteRendererComp = CountNumbersGO.GetComponent<SpriteRenderer>();

        CarControllerGo = this.GetGameObjectByType<CarController>(); 

        CarGo = this.GetGameObjectByType<Car>();

        Init();
    }

    private void Init()
    {
        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        CarControllerGo.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        SpriteRendererComp.sprite = numbers[1];
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        SpriteRendererComp.sprite = numbers[2];
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        SpriteRendererComp.sprite = numbers[3];
        RouteEngineComp.StartGame = true;
        CountNumbersGO.GetComponent<AudioSource>().Play();
        CarGo.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        CountNumbersGO.SetActive(false);
    }
}
