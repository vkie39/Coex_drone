using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneController : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float changeDirectionEverySeconds = 2f;
    private float changeDirectionTimer = 0;
    private float movementRangeX = 250.0f;  // x 이동 범위 
    private float movementRangeY = 25.0f;  // y 이동 범위 
    private float movementRangeZ = 50.0f;  // z 이동 범위

    void Start()
    {
        Application.targetFrameRate = 60;
        startPosition = transform.position;  // 초기 위치 저장
        ChangeTargetPosition();
    }

    void Update()
    {
        if (changeDirectionTimer > changeDirectionEverySeconds)
        {
            ChangeTargetPosition();
            changeDirectionTimer = 0;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        changeDirectionTimer += Time.deltaTime;
    }

    void ChangeTargetPosition()
    {
        float x = Random.Range(startPosition.x - movementRangeX, startPosition.x + movementRangeX);
        float y = Random.Range(startPosition.y - movementRangeY, startPosition.y + movementRangeY);
        float z = Random.Range(startPosition.z - movementRangeZ, startPosition.z + movementRangeZ);
        targetPosition = new Vector3(x, y, z);
    }
}
