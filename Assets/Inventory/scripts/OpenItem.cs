using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenItem : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject buttonOpen;
    public GameObject buttonClose;
    private bool isButton;
    private bool usingButton;

    // Start is called before the first frame update
    void Start()
    {
        inventoryPanel.SetActive(false);
        buttonOpen.SetActive(true);
        buttonClose.SetActive(false);
        isButton = false;
    }


    public void OpenInventory()
    {
       
        isButton = !isButton;
        if (isButton)
        {
            inventoryPanel.SetActive(true);

            buttonOpen.SetActive(false);
            buttonClose.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);

            buttonOpen.SetActive(true);
            buttonClose.SetActive(false);
        }
        Debug.Log(isButton);
    }

}
