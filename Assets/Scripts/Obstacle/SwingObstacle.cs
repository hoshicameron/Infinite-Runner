using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
    [SerializeField] private float minRotateSpeed = 0;
    [SerializeField] private float maxRotateSpeed = 0;

    [SerializeField] private float minZRotation;
    [SerializeField] private float maxZRotation;

    private float rotateSpeed = 0;
    private float zAngle;
    private void OnEnable()
    {
        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);

        if (Random.Range(0, 2) > 0) rotateSpeed *= -1;
    }

    private void Update()
    {
        zAngle += rotateSpeed * Time.deltaTime;
        transform.rotation=Quaternion.AngleAxis(zAngle,Vector3.forward);

        if (transform.rotation.z < minZRotation) rotateSpeed = Mathf.Abs(rotateSpeed);
        if (transform.rotation.z > maxZRotation) rotateSpeed = -Mathf.Abs(rotateSpeed);


    }
}
