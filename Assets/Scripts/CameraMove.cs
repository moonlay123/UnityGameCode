using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    public Camera Camera;
    public GameObject Canvas;
    private void Start()
    {
        Camera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        Camera.transform.position=new Vector3(Player.transform.position.x, Camera.transform.position.y,Camera.transform.position.z);
        Canvas.transform.position = Camera.transform.position;
    }
}
