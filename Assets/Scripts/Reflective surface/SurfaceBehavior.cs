using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceBehavior : MonoBehaviour
{
    private ISurface surface; 

    [SerializeField]
    private float absorptionCoefficient;
    void Start()
    {
        surface = new Surface(absorptionCoefficient);
    }

    public ISurface Surface => surface;
}
