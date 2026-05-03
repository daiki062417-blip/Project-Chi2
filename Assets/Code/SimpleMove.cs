using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // A/D or Å©Å®
        float z = Input.GetAxis("Vertical");   // W/S or Å™Å´


        Vector3 move = new Vector3(x, 0, z);
        transform.Translate(move * Time.deltaTime * 5f);
    }
}
