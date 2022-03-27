
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadePanelScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI fadePanelTime;
    [SerializeField] TextMeshProUGUI daytime;

    // Update is called once per frame
    void Update()
    {
        fadePanelTime.text = daytime.text;
    }
}
