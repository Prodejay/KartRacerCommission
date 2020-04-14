using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongButtonPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public float requiredHoldTime;

    [SerializeField]
    private UnityEvent onLongClick;

    //Required function for IPointerDownHandler Interface to work
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("OnPointerDown");
    }


    //Required function for IPointerUpHandler Interface to work

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("OnPointerUp");
        FindObjectOfType<KartGame.KartSystems.KeyboardInput>().forward = false;
        FindObjectOfType<KartGame.KartSystems.KeyboardInput>().backward = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if(onLongClick != null)
                {
                    onLongClick.Invoke();
                }
                
            }
        }     
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }
}
