using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    //todo this is done here and in FPC but probably shouldn't
    private Inputs _input;
    [SerializeField]
    private TimeController _timeController;
    private GameObject _mainCamera;
    [SerializeField]
    private GameObject SeekShelterText;

    [SerializeField]
    private GameObject HoursPanel;
    
    [SerializeField]
    private GameObject FadePanel;

    [SerializeField]
    private GameObject CraftingCanvas;
    
    [SerializeField]
    private TextMeshProUGUI _sliderValue;

    [SerializeField] Image health;

    [SerializeField] Image moral;
    private RaycastHit hit;
    private DateTime recordedTime;
    private bool timeFlag = true;
    private float recordedtimeSpeed = 0;
    private bool resting = false;
    private bool mFaded = false;
    private float duration = 0.4f;

    [SerializeField]
    private Rigidbody rock;


    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<Inputs>();
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(resting)
        {
            if(_timeController.currentTime >= recordedTime.AddHours(float.Parse(_sliderValue.text)))
                {
                    _timeController.timeMultiplier = recordedtimeSpeed;                    
                    resting = !resting;
                    timeFlag = !timeFlag;                    
                    health.fillAmount = 1;
                    moral.fillAmount = 1;
                    Fade();
                }
        }
        if (_input.fire)
        {
            //todo that shouldn't be happening the same is with jumping
            _input.fire = false;
            
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out hit, 3f, 0b1))
            {
                    ItemPickup item;
                    if(item = hit.transform.GetComponent<ItemPickup>())
                    {
                        if(item.itemInfo.itemName == "Water")
                        {
                            if(PlayerManager.Instance.inventory.items.Contains(item.itemInfo._waterBottle))
                            {
                                PlayerManager.Instance.inventory.Remove(item.itemInfo._waterBottle);
                                PlayerManager.Instance.inventory.Add(item.itemInfo);
                            }
                        }
                        else
                        {
                            PlayerManager.Instance.inventory.Add(item.itemInfo);
                            Destroy(hit.transform.gameObject);
                        }
                            
                    }
            }
            if (Physics.Raycast(ray, out hit, 3f, 0b1000000))
            {
                GoToSleep();
            }
            if (Physics.Raycast(ray, out hit, 3f, 0b100000000))//8th layer "Printer"
            {
                CraftingCanvas.SetActive(true);
                CraftingCanvas.GetComponentInChildren<CraftingManager>().UpdateItems();
                PlayerManager.Instance.LockCursor(false);
            }
        }
        if (Input.GetKeyDown("r"))
        {
            Rigidbody r = Instantiate(rock, _mainCamera.transform.position + _mainCamera.transform.forward, _mainCamera.transform.rotation);
            r.velocity = _mainCamera.transform.forward * 40;
        }
    }

    private void GoToSleep()
    {
        if(HoursPanel.activeSelf)
        {       
            if (float.Parse(_sliderValue.text) > 0)
            {
                if(timeFlag)
                {
                    FadePanel.SetActive(true);
                    Fade();
                    recordedtimeSpeed = _timeController.timeMultiplier;
                    _timeController.timeMultiplier = 4000;
                    recordedTime = _timeController.currentTime;                    
                    timeFlag = !timeFlag;
                    resting = !resting;
                }
                SeekShelterText.SetActive(false);
                HoursPanel.SetActive(false);
            }
        }
        else if (SeekShelterText.activeSelf)
        {
            //diactivate seek shelter and activate selection dragbar
            SeekShelterText.SetActive(false);
            HoursPanel.SetActive(true);
        }
        //if we click on the cave object
        else if( hit.transform.gameObject.name == "Cave")
        {
            //display seek shelter text
            SeekShelterText.SetActive(true);
            //if action button is clicked while seek shelter is displayed
        }
 
    }

    private void Fade() {
        {
            var cGroup = FadePanel.GetComponent<CanvasGroup>();
            StartCoroutine(DoFade(cGroup, cGroup.alpha, mFaded ? 0 : 1));
            mFaded = !mFaded;
        }
    }
    public IEnumerator DoFade(CanvasGroup cGroup, float start, float end)
    {
        float counter = 0f;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            cGroup.alpha = Mathf.Lerp(start, end, counter/duration);
            yield return null;
        }
    }
}
