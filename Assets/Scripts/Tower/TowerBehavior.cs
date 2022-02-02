using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    private ITower tower;
    private ILaser laser;

    [SerializeField]
    private GameObject line;

    [SerializeField]
    private float range;

    [SerializeField]
    private float power;

    [SerializeField]
    private Transform turretTransform;

    [SerializeField]
    private Transform baseTransform;

    void Awake()
    {
        laser = new Laser(range, power, line);
        tower = new Tower(baseTransform, laser, turretTransform);
    }
    void Start()
    {
        tower.LaunchLaser(tower.Transform.position, tower.TurretTransform.up);
    }

    public void LeftRotation()
    {
        tower.Rotation(-10.0f);
    }

    public void RightRotation()
    {
        tower.Rotation(10.0f);
    }

    public void UpTilt()
    {
        if (tower.TurretTransform.rotation.eulerAngles.z < 80)
        {
            tower.Tilt(Quaternion.AngleAxis(5.0f, Vector3.forward));
        }
    }

    public void DownTilt()
    {
        if (tower.TurretTransform.rotation.eulerAngles.z > 5)
        {
            tower.Tilt(Quaternion.AngleAxis(-5.0f, Vector3.forward));
        }
    }

    public void LauchLaser()
    {
        tower.LaunchLaser(tower.TurretTransform.position, tower.TurretTransform.up);
    }
}
