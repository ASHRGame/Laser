using UnityEngine;
using System.Collections;

public class MouseMove: MonoBehaviour
{

    private GameObject go;

    [SerializeField]
    private float sensitivity = 1f;
    [SerializeField]
    private Camera goCamera;
    private Vector3 MousePos;
    private float MyAngle = 0F;

    void Start()
    {
        go = goCamera.transform.parent.gameObject;
    }

    void Update()
    {
        MousePos = Input.mousePosition;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            MyAngle = 0;
            MyAngle = sensitivity * ((MousePos.x - (Screen.width / 2)) / Screen.width);
            goCamera.transform.RotateAround(go.transform.position, goCamera.transform.up, MyAngle);
            MyAngle = sensitivity * ((MousePos.y - (Screen.height / 2)) / Screen.height);
            goCamera.transform.RotateAround(go.transform.position, goCamera.transform.right, -MyAngle);
        }
    }
}