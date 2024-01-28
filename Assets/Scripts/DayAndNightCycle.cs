using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DayAndNightCycle : MonoBehaviour
{
    [SerializeField] private Gradient lightColor;
    [SerializeField] private GameObject lightObject;

    private float time = 5;

    private void Update()
    {
        if (time > 50){
            time = 0;
        }
    
        time += Time.deltaTime;
        lightObject.GetComponent<Light>().color = lightColor.Evaluate(time * 0.02f);
    }
}
