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
    public GameObject ui;
    public GameObject thePlayer;
    private bool checkInput = false;
    [SerializeField]private bool doOnce = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShowUI();
            checkInput = true;
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
        //if (Input.GetButtonDown(KeyCode.E))
        if (checkInput && InputSystem.Interact && !doOnce)
        {
            thePlayer.transform.position = TeleportTarget.transform.position;
            doOnce = true;
        }
    }
    
}
