using UnityEngine;



public interface ILaser
{
    void RemoveOldLines();
    
    void Launch(Vector3 startPositionLaser, Vector3 direction);

    void DrawLaser(Vector3 startPositionLaser, Vector3 finistPositionLaser);
}