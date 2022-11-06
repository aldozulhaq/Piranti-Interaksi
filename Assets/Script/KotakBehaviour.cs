using System;
using System.IO.Ports;
using UnityEngine;

public class KotakBehaviour : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM6", 115200);
    public string data_string;
    public float rotSpeed = 50f;

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
            data_stream.ReadTimeout = 10000;
            string[] datas = data_string.Split('|');

            float x = float.Parse(datas[0]);
            float y = float.Parse(datas[1]);
            float z = float.Parse(datas[2]) - 90;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(x * -1, 0f, y * -1), rotSpeed * Time.deltaTime);

        }
        catch (TimeoutException) { }
    }

    private void OnApplicationQuit()
    {
        data_stream.Close();
    }
}
