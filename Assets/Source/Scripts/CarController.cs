using UnityEngine;

public class CarController : MonoBehaviour
{
    private GameObject carGo;

    public float TurningAngle;
    public float Speed;

    void Start()
    {
        carGo = this.GetGameObjectByType<Car>();
    }

    void FixedUpdate()
    {
        float turningZ = 0; 
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime);

        turningZ = Input.GetAxis("Horizontal") * -TurningAngle;

        carGo.transform.rotation = Quaternion.Euler(0, 0, turningZ);
    }
}
