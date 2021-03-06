using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class ToggleObject : MonoBehaviour {

    public GameObject toToggle;

    private VRTK_Button_UnityEvents buttonEvents;

    private void Start()
    {
        buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
        if (buttonEvents == null)
        {
            buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
        }
        buttonEvents.OnPushed.AddListener(handlePush);
    }

    private void handlePush(object sender, Control3DEventArgs e)
    {
        toToggle.SetActive(!toToggle.activeSelf);
    }
}
