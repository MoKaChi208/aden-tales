using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCSign : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool PlayerInRange;
    private NPCHandle NPCHandle;
    // Start is called before the first frame update
    private void Awake()
    {
        NPCHandle = GetComponentInParent<NPCHandle>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NPCHandle.GetMouseNPC() == true && PlayerInRange == false) {
            NPCHandle.SetMouseNPC(false);
        }
        if ((Input.GetKeyDown(KeyCode.Space) || NPCHandle.GetMouseNPC() == true) && PlayerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                NPCHandle.SetMouseNPC(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                NPCHandle.SetMouseNPC(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            //Debug.Log("Player in range");
            PlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player left range");
            PlayerInRange = false;
            dialogBox.SetActive(false);
        }
    }

 
}
