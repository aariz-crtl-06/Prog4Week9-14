using UnityEngine;

public class Computer : MonoBehaviour
{
    public bool isBroken = false;
    public Renderer rend;

    void Start()
    {
        if (rend == null)
            rend = GetComponentInChildren<Renderer>();

        UpdateColor();
    }

    void Update()
    {
        // Random chance to break (only if not already broken)
        //if (!isBroken && Random.Range(0f, 1f) < 0.0005f)
        //{
        //    BreakComputer();
        //}
    }

    public void BreakComputer()
    {
        isBroken = true;
        UpdateColor();
    }

    public void FixComputer()
    {
        isBroken = false;
        UpdateColor();
    }

    void UpdateColor()
    {
        if (rend != null)
        {
            rend.material.color = isBroken ? Color.red : Color.green;
        }
    }
}