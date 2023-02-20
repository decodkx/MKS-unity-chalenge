using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float smoothTime = 0.3F;
    [SerializeField] private Transform playerPos; 
    private Vector3 velocity = Vector3.zero;
    private float cameraStartDistance;
    void Start()
    {
        cameraStartDistance = this.gameObject.transform.position.z;
    }



    void Update()
    {
        Vector3 targetPosition = playerPos.TransformPoint(new Vector3(0, 1, -10));

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
