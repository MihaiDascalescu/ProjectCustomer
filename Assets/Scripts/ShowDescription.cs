using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDescription : MonoBehaviour
{
    public GameObject Description;
    // Start is called before the first frame update
    private void OnMouseOver()
    {
        Description.SetActive(true);
    }

    private void OnMouseExit()
    {
        Description.SetActive(false);
    }
}
