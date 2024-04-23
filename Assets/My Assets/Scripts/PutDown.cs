using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PutDown : MonoBehaviour
{

    [SerializeField] InputAction input;
    public StarterAssetsInputs InputSystem;
    public GameObject heldObject;
    public GameObject theObject;
    public GameObject ui;
    private bool checkInput = false;
    [SerializeField] private bool doOnce = false;


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
        if (checkInput && InputSystem.Interact && !doOnce)
        {
            heldObject.transform.SetParent(theObject.transform);
            heldObject.transform.localPosition = new Vector3(0f, 1.2f, 0f);
            heldObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            doOnce = true;
            HideUI();
        }
    }

}
