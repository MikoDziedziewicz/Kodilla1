using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public Slider slider;
    public int timeToReachMaxValue = 10;
    private float maxSliderValue;
    private float minSliderValue;
    private float sliderValue;

    private float targetValue;  // wartość docelowa suwaka
    private float changeSpeed;  // prędkość zmiany wartości suwaka

    // Start is called before the first frame update
    void Start()
    {
        maxSliderValue = slider.maxValue;
        minSliderValue = slider.minValue;
        sliderValue = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        // nie wykonuje obliczen, jesli wartosc suwaka nie zostala zmieniona 
        if (slider.value != targetValue)
        {
            targetValue = Mathf.Clamp(sliderValue, minSliderValue, maxSliderValue);
            changeSpeed = Mathf.Abs(targetValue - slider.value) / timeToReachMaxValue;
        }

        slider.value = Mathf.MoveTowards(slider.value, targetValue, changeSpeed * Time.deltaTime);
    }
}
