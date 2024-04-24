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
    public GameObject Beach1;
    public GameObject Beach2;
    public GameObject Basement1;
    public GameObject Basement2;
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

    public void HideBeachSound()
    {
        Beach1.SetActive(false);
        Beach2.SetActive(false);
    }

    public void HideBasementSound()
    {
        Basement1.SetActive(false);
        Basement2.SetActive(false);
    }

    public void PlayBeachSound()
    {
        Beach1.SetActive(true);
        Beach2.SetActive(true);
    }

    public void PlayBasementSound()
    {
        Basement1.SetActive(true);
        Basement2.SetActive(true);
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
        PlayBeachSound();
        HideBasementSound();
    }

    // Update is called once per frame
    void Update()
    {
        Unlocked = GameObject.Find("Balcony_Post").GetComponent<PutDown>().unlocked;
        //if (Input.GetButtonDown(KeyCode.E))
        if (checkInput && InputSystem.Interact && !doOnce)
        {
            thePlayer.transform.position = TeleportTarget.transform.position;
            HideBeachSound();
            PlayBasementSound();
            doOnce = true;
        }
    }
    
}
