using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour
{
    public float maxValue = 8.0f; // or whatever you want the max value to be
    public float minValue = 4.0f; // or whatever you want the min value to be
    public float currentValue; // or wherever you want to start
    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = transform.position.x;
        currentValue += Time.deltaTime * direction;

    if(currentValue >= maxValue) 
    {
       direction *= -1;
       currentValue = maxValue;
    }
    else if (currentValue <= minValue)
    {
       direction *= -1; 
       currentValue = minValue;
    }
    transform.position = new Vector3(currentValue, transform.position.y, transform.position.z);
    }
}
