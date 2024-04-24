using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp2 : MonoBehaviour
{

    [SerializeField] InputAction input;
    public StarterAssetsInputs InputSystem;
    public GameObject thePlayer;
    public GameObject theObject;
    public GameObject ui;
    private bool checkInput = false;
    public bool PickedUp = false;
    [SerializeField] private bool doOnce = false;


    private void OnTriggerEnter(Collider other)
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

    // Update is called once per frame
    void Update()
    {
        if (checkInput && InputSystem.Interact && !doOnce)
        {
            theObject.transform.SetParent(thePlayer.transform);
            theObject.transform.localPosition = new Vector3(0f, 0f, 0f);
            PickedUp = true;
            doOnce = true;
            HideUI();
        }
    }

}