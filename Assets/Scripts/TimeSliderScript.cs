using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeSliderScript : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;

    void Start()
    {
        _slider.onValueChanged.AddListener((v) =>{
            _sliderText.text = v.ToString("0.00");
        });
    }
    // Update is called once per frame
    void Update()
    {
        _slider.value += Input.mouseScrollDelta.y;
    }
}
