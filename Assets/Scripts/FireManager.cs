using UnityEngine;
using System.Collections.Generic;

public class FireManager : MonoBehaviour
{
    public List<Fire> fires;

    void Start(){
        fires = new List<Fire>(GetComponentsInChildren<Fire>());
    }

    public void OnWaterDropped()
    {
        for (int i = 0; i < fires.Count; i++)
        {
            if (!fires[i])
            {
                fires.RemoveAt(i);
                i--;
            }
            else
                fires[i].Diminish();
        }
    }

    public bool IsAnyFireLeft
    {
        get
        {
            return fires.Count > 0;
        }
    }
}