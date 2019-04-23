using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{

    public RouteEngine RouteEngineComp;
    public Sprite[] numbers;
    public SpriteRenderer SpriteRendererComp;

    public GameObject CarControllerGo;
    private GameObject carGo;

    public GameObject CountNumbersGO;

    void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        RouteEngineComp = RouteEngine.Instance;

        SpriteRendererComp = CountNumbersGO.GetComponent<SpriteRenderer>();

        CarControllerGo = CarController.Instance.gameObject; 

        carGo = Car.Instance.gameObject;

        Init();
    }

    private void Init()
    {
        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        CarControllerGo.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        SpriteRendererComp.sprite = numbers[1];
        audioSource.Play();
        yield return new WaitForSeconds(1);

        SpriteRendererComp.sprite = numbers[2];
        audioSource.Play();
        yield return new WaitForSeconds(1);

        SpriteRendererComp.sprite = numbers[3];
        RouteEngineComp.StartGame = true;
        CountNumbersGO.GetComponent<AudioSource>().Play();
        carGo.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        CountNumbersGO.SetActive(false);
    }
}
