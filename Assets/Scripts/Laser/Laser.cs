using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Laser : ILaser
{
    private readonly float range;
    private float power;

    private readonly GameObject linePrefab;

    private IList<GameObject> lines;


    public Laser(float range, float power, GameObject linePrefab)
    {
        this.range = range;
        this.power = power;
        this.linePrefab = linePrefab;
        lines = new List<GameObject>();
    }

    public void RemoveOldLines()
    {
        if (lines.Count > 0)
        {
            GameObject.Destroy(lines.LastOrDefault());
            lines.Remove(lines.LastOrDefault());
            RemoveOldLines();
        }
    }


    public void Launch(Vector3 startPositionLaser, Vector3 direction)
    {
        RaycastHit hit;
        Ray ray = new Ray(startPositionLaser, direction);

        bool intersect = Physics.Raycast(ray, out hit, range);
        //Debug.DrawRay(startPositionLaser, direction * range, Color.red);
        Vector3 hitPosition = hit.point;
        if (intersect == false)
        {
            hitPosition = startPositionLaser + direction * range;
        }
        DrawLaser(startPositionLaser, hitPosition);

        if (intersect && power > 0)
        {
            power -= hit.transform.gameObject.GetComponent<SurfaceBehavior>().Surface.AbsorptionCoefficient;
            Launch(hitPosition, Vector3.Reflect(direction, hit.normal));
        }
        Debug.Log(power);
    }

    public void DrawLaser(Vector3 startPositionLaser, Vector3 finishPositionLaser)
    {
        GameObject go = GameObject.Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        LineRenderer lineRender = linePrefab.GetComponent<LineRenderer>();
        lines.Add(go);
        lineRender.SetPosition(0, startPositionLaser);
        lineRender.SetPosition(1, finishPositionLaser);
    }
}