using UnityEngine;

public class AnimFixer : MonoBehaviour
{
    public float speed;

    void Start()
    {
        foreach (AnimationState s in animation)
            s.speed = speed;
    }
}