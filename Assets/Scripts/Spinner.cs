using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float xAngle = 0;
    [SerializeField] float yAngle = 0;
    [SerializeField] float zAngle = 0;
    void Update()
    {
        transform.Rotate(xAngle * speed * Time.deltaTime, yAngle * speed * Time.deltaTime, zAngle * speed * Time.deltaTime);
    }
}
