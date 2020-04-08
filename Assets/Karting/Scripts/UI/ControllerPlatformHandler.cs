using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This Script just sets what control scheme would be used
public class ControllerPlatformHandler : MonoBehaviour
{

    public static ControllerPlatformHandler instance;

    public bool computerControls;

    public bool touchControls;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
