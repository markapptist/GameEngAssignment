using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class LoadObj : MonoBehaviour
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
    private static extern float reX();

    [DllImport(DLL_NAME)]
    private static extern float reY();

    [DllImport(DLL_NAME)]
    private static extern float reZ();

    [DllImport(DLL_NAME)]
    private static extern void readPosition();
    public void LoadPosition()
    {
        readPosition();
        
        Vector3 newposi = new Vector3(reX(), reY(), reZ());
        float step = 1000 * Time.deltaTime;
        GameObject.Find("Cube").transform.position = Vector3.MoveTowards(GameObject.Find("Cube").transform.position, newposi, step);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            LoadPosition();
        }
    }
}
