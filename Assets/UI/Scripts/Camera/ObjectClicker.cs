using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
     private string layerTag = "";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                //Debug.Log("Target Name: " + hit.collider.gameObject.name);
                //Debug.Log("Target Name: " + hit.collider.gameObject.tag);
                layerTag = hit.collider.gameObject.tag;


            }
        }
    }
    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }
    public string GetTag() {
        return layerTag;
    }

}
