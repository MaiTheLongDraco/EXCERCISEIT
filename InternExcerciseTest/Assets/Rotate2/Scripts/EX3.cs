using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EX3 : MonoBehaviour
{
    private float leftLimit = -30f;
    private float rightLimit = 30f;
    private bool isDragging;
    private Vector3 initialMousePosition;
    Vector3 currentMousePosition;
    private Quaternion initialRotation;
    [SerializeField] float rotationSpeed = 20f;
    float RTAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPointTo();
    }
    private void CheckPointTo()
    {
        if(Input.GetMouseButtonDown(0))
        {
            initialMousePosition=Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            isDragging=true;
            currentMousePosition = Input.mousePosition;
            Vector3 mouseOffset = currentMousePosition - initialMousePosition;
            float rotation = mouseOffset.x * rotationSpeed * Time.deltaTime;
            Debug.Log("rotation" + rotation);
            RTAngle = transform.localEulerAngles.y + rotation;
            Debug.Log("RTAngle" + RTAngle);
        }    
        if(isDragging)
        {
            if (RTAngle>180)
                RTAngle -= 360f;
            RTAngle = Mathf.Clamp(RTAngle, leftLimit, rightLimit);
                transform.localEulerAngles=new Vector3(transform.localEulerAngles.x, RTAngle, transform.localEulerAngles.z);
            
        }
    }
   
}
