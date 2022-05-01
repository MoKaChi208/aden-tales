using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCHandle : MonoBehaviour
{
    public Vector3 positonNPC;
    private bool mouseNPC;
    private bool check;
    private void Start()
    {
        mouseNPC = false;

    }
    private void Update()
    {
        //Debug.Log("check" + check);
    }
    private void OnMouseDown()
    {
        //Debug.Log("Mouse in range");
        //Debug.Log(transform.position);
        positonNPC = transform.position;
        mouseNPC = true;

    }
    public Vector3 GetPositionNPC() {
        return positonNPC;
    }
    public bool GetMouseNPC()
    {
        return mouseNPC;
    }
    public void SetMouseNPC(bool mouseSetNPC)
    {
        mouseNPC = mouseSetNPC;
    }
}
