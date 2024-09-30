using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed;
    public Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        rotate = new Vector3(45, 50, 90);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotate * Time.deltaTime * speed);
    }
}
