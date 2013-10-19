using UnityEngine;

public class HelicopterWater : MonoBehaviour
{
    public FireManager fireManager;
    public float waterForce;

    public float maxCapacity = 3f;
    public float current = 3f;
    public float decreaseSpeed = 0.3f;

    public Lake lakeInRange;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            DropWater();

        if (lakeInRange)
            RegenWater();
    }

    public void DropWater()
    {
        current = Mathf.Clamp(current - decreaseSpeed * Time.deltaTime, 0, maxCapacity);
        fireManager.OnWaterDropped();
    }

    public void RegenWater()
    {
        current = Mathf.Clamp(current + lakeInRange.regenSpeed * Time.deltaTime, 0, maxCapacity);
    }

    void OnTriggerEnter(Collider c)
    {
        lakeInRange = c.GetComponent<Lake>();
    }
}