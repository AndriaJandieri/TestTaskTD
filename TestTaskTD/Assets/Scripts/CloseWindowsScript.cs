using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindowsScript : MonoBehaviour
{
    public GameObject[] windows;

    public void CloseAllWindows()
    {
        foreach (GameObject window in windows)
        {
            window.SetActive(false);
        }
    }
}
