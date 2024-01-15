using UnityEngine;
using Radish;

public class Test : MonoBehaviour
{
    public NetworkingGraph graph;
    public int pushSpeed = 30;

    int frameCount;
    void FixedUpdate()
    {
        if (frameCount++ % pushSpeed == 0)
        {
            graph.PushValue(0, Random.Range(0, 150));
            graph.PushValue(1, Random.Range(0, 150));
            graph.PushValue(2, Random.Range(0, 150));
            graph.DisplayValues();
        }
    }
}
