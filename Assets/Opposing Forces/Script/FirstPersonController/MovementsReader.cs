using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.Rendering;

public class MovementReader : MonoBehaviour
{
    public Blackboard blackboard;

    public float movements;

    public GameObject h1;
    public GameObject h2;
    public GameObject h3;

    void Update()
    {
       movements = blackboard.GetVariableValue<float>("movements");

        if (movements == 0)
        {
            h1.SetActive(true);
            h2.SetActive(true);
            h3.SetActive(true);
        }
        else if (movements == 1)
        {
            h1.SetActive(true);
            h2.SetActive(true);
            h3.SetActive(false);
        }
        else if (movements == 2)
        {
            h1.SetActive(true);
            h2.SetActive(false);
            h3.SetActive(false);
        }

        else if (movements == 3)
        {
            h1.SetActive(false);
            h2.SetActive(false);
            h3.SetActive(false);
        }
    }
}