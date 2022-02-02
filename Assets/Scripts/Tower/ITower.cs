using UnityEngine;

public interface ITower
{
    Transform TurretTransform { get; }

    Transform Transform { get; }


    void Tilt(Quaternion rotation);

    void Rotation(float rotate);

    void LaunchLaser(Vector3 startPositionLaser, Vector3 direction);
}
