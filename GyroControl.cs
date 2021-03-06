using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject Cube;
    private Quaternion rotation;
    //private float speed = 5f;
    //private Rigidbody _rb;
    private float dist;
    private Vector3 vol;
    //private float forward;

    private void Start()
    {
       Cube = new GameObject("Cube");
       Cube.transform.position = transform.position;
       //_rb = GetComponent<Rigidbody> ();
        transform.SetParent(Cube.transform);
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            Cube.transform.rotation = Quaternion.Euler(90f, -90f, -90f);
            rotation = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rotation;
            Debug.Log(Input.acceleration.z);

            if (gyro.userAcceleration.z > .04f)
            {
                transform.Translate(0, 0, 4f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Backspace) || (Input.GetMouseButton(0)))
            {
                Application.Quit();
            }
           // Debug.Log (forward);	
        }
        if (Input.anyKeyDown) 
        {
            Application.Quit();
            
        }
    }
}
