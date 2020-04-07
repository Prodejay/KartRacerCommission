using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchUIHandlerScript : MonoBehaviour
{
    TouchUIHandlerScript instance;

    public GameObject touchUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!ControllerPlatformHandler.instance.touchControls)
        {
            touchUI.SetActive(false);
        }
        else
        {
            touchUI.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
