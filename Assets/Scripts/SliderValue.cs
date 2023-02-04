using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public Slider slider;
    public int timeToReachMaxValue = 10;
    private float maxSliderValue = 10.0f;
    private float minSliderValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = minSliderValue;
        slider.maxValue = maxSliderValue;
        slider.value = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value += (maxSliderValue / timeToReachMaxValue) * Time.deltaTime;
    }
}
