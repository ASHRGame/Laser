using UnityEngine;
using System.Collections.Generic;

public class Tower : ITower
{
    private ILaser laser;
    private Transform transform;

    private Transform turretTransform;

    public Transform TurretTransform => turretTransform;
    public Transform Transform => transform;

    public Tower(Transform transform, ILaser laser)
    {
        this.transform = transform;
        this.laser = laser;
    }
    public Tower(Transform transform, ILaser laser, Transform turretTransform) : this(transform, laser)
    {
        this.turretTransform = turretTransform;
    }

    public void Tilt(Quaternion rotation)
    {
        turretTransform.rotation *= rotation;
    }

    public void Rotation(float rotate)
    {
        transform.Rotate(0, rotate, 0, Space.Self);
        turretTransform.Rotate(0, rotate, 0, Space.World);
    }


    public void LaunchLaser(Vector3 startPositionLaser, Vector3 direction)
    {
        laser.RemoveOldLines();
        laser.Launch(startPositionLaser, direction);
    }

}
