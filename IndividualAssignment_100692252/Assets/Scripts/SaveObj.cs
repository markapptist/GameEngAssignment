using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class SaveObj : MonoBehaviour
{
    const string DLL_NAME = "DLLPlugin";
    [DllImport(DLL_NAME)]
    private static extern int SimpleFunction();

    [DllImport(DLL_NAME)]
    private static extern void readX(float xP);

    [DllImport(DLL_NAME)]
    private static extern void readY(float yP);

    [DllImport(DLL_NAME)]
    private static extern void readZ(float zP);

    [DllImport(DLL_NAME)]
    private static extern void writePosition();
    public void SavePosition()
    {
        readX(GameObject.Find("Cube").transform.position.x);
        readY(GameObject.Find("Cube").transform.position.y);
        readZ(GameObject.Find("Cube").transform.position.z);
        writePosition();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SavePosition();
        }
    }
}