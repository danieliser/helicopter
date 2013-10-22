using UnityEngine;

public class HelicopterWater : MonoBehaviour
{
    public FireManager fireManager;
    public float waterForce;

    public float maxCapacity = 3f;
    public float current = 3f;
    public float decreaseSpeed = 0.3f;

    public Lake lakeInRange;

    public ParticleSystem pSys;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && current > 0)
            DropWater();
        if (Input.GetKeyDown(KeyCode.Space) || current == 0)
            StartWater();
        if(Input.GetKeyUp(KeyCode.Space))
            StopWater();

        if (lakeInRange)
            RegenWater();
    }

    public void DropWater()
    {
        if(pSys.isStopped)
            pSys.Play();
        current = Mathf.Clamp(current - decreaseSpeed * Time.deltaTime, 0, maxCapacity);
        fireManager.OnWaterDropped();
    }

    private void StartWater()
    {
        pSys.Play();
    }

    public void StopWater()
    {
        pSys.Stop();
    }

    public void RegenWater()
    {
        current = Mathf.Clamp(current + lakeInRange.regenSpeed * Time.deltaTime, 0, maxCapacity);
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.CompareTag("lake"))
            lakeInRange = c.GetComponent<Lake>();
    }

    void OnTriggerExit(Collider c)
    {
        if(c.CompareTag("lake"))
            lakeInRange = null;
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Box("Capacity: ");
        GUILayout.HorizontalSlider(current, 0, maxCapacity, GUILayout.MinWidth(200));
        GUILayout.EndHorizontal();
    }
}