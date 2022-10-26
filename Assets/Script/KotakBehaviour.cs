using System;
using System.IO.Ports;
using UnityEngine;

public class KotakBehaviour : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM6", 115200);
    public string data_string;
    //private Gyroscope gyro;
    private void Start()
    {
        try
        {
            data_stream.Open();
        }
        catch (Exception e)
        {
            Debug.Log("Could not open serial port: " + e.Message);
        }
    }

    private void Update()
    {
        try
        {
            data_string = data_stream.ReadLine();
            data_stream.ReadTimeout = 1000;
            string[] datas = data_string.Split('|');

            float x = float.Parse(datas[0]) - 25;
            float y = float.Parse(datas[1]);
            float z = float.Parse(datas[2]) - 90;

            float rotSpeed = 50f;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(x * -1, 0f, y * -1), rotSpeed * Time.deltaTime);
            //transform.localEulerAngles = (new Vector3(x, 0f, y) * -1);
            //transform.localRotation = Quaternion.Lerp(x, y, z);
        }
        catch (TimeoutException) { }
    }

    private void OnApplicationQuit()
    {
        data_stream.Close();
    }
}
