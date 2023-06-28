using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float rotateSpeed = Time.deltaTime * 60;
        this.transform.Rotate(rotateSpeed, rotateSpeed, rotateSpeed);
    }
}
