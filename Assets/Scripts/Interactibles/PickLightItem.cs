using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickLightItem : MonoBehaviour
{
    public float _distance;
    
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject actionText;

    public GameObject helditem;

    void Update()
    {
        // Check distance from Item
        _distance = PlayerCasting.DistanceFromTarget;

    }

    // Mouse is over item
    private void OnMouseOver()
    {
        // close to the item a text and the cursor appears, otherwise, they disappear
        if (_distance <= 2f)
        {
            actionText.GetComponent<Text>().text = "This might be useful!";
            actionText.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            actionText.SetActive(false);
            Cursor.visible = false;
            
        }
        // picking up the item by clicking the MouseButton
        if (Input.GetMouseButtonDown(0))
        {
            if (_distance <= 2f)
            {
                item.SetActive(false);
                helditem.SetActive(true);
                actionText.SetActive(false);
                Cursor.visible = false;
            }
        }
    }
    
    // if the mouse is not on the item make text and cursor disappear
    private void OnMouseExit()
    {
        actionText.SetActive(false);
        Cursor.visible = false;
    }
}
