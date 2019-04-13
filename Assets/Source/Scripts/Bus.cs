using UnityEngine;

public class Bus : MonoBehaviour
{
    private Chronometer chronometerComp;
    private AudioFx audioFXComp;

    private void Start()
    {
        chronometerComp = this.GetComponentFromUniqueInstance<Chronometer>();

        audioFXComp = this.GetComponentFromUniqueInstance<AudioFx>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Car>() != null)
        {
            audioFXComp.FXSoundCarCrash();
            chronometerComp.TimeValue -= 20;

            Destroy(gameObject);
        }
    }
}
