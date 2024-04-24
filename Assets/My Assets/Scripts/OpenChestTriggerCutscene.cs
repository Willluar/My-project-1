using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenChestTriggerCutscene : MonoBehaviour
{
    [SerializeField] InputAction input;
    public StarterAssetsInputs InputSystem;
    public GameObject thePlayer;
    public GameObject theObject;
    public GameObject ui;
    public bool pickedUp = false;
    private bool checkInput = false;
    [SerializeField] private bool doOnce = false;
    public Vector3 rotationDirection;
 

    private void OnTriggerEnter(Collider other)
    {
        if (pickedUp)
        {
            if (!doOnce)
            {
                if (other.tag == "Player")
                {
                    ShowUI();
                    checkInput = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            HideUI();
            checkInput = false;
        }
    }

    public void ShowUI()
    {
        ui.SetActive(true);
    }
    public void HideUI()
    {
        ui.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        HideUI();
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
    void Open()
    {
        transform.Rotate(rotationDirection );
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        
        pickedUp = GameObject.Find("photo").GetComponent<PickUp2>().PickedUp;
        if (checkInput && InputSystem.Interact && !doOnce)
        {
            doOnce = true;
            HideUI();
            Open();
            
        }
    }
}
