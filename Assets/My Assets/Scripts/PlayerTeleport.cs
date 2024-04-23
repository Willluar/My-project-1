using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] InputAction input;
    public Transform TeleportTarget;
    public StarterAssetsInputs InputSystem;
    public GameObject Lockedui;
    public GameObject Openui;
    public GameObject thePlayer;
    public bool Unlocked = false;
    private bool checkInput = false;
    [SerializeField]private bool doOnce = false;
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (Unlocked)
        {
            if (other.tag == "Player")
            {
                ShowOpenUI();
                checkInput = true;
            }
        }
        else
        {
            ShowLockedUI();
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

    public void ShowLockedUI()
    {
        Lockedui.SetActive(true);
    }
    public void ShowOpenUI()
    {
        Openui.SetActive(true);
    }
    public void HideUI()
    {
        Lockedui.SetActive(false);
        Openui.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        HideUI();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetButtonDown(KeyCode.E))
        if (checkInput && InputSystem.Interact && !doOnce)
        {
            thePlayer.transform.position = TeleportTarget.transform.position;
            doOnce = true;
        }
    }
    
}
