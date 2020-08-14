﻿using System.Collections.Generic;
using UnityEngine;
/*! \brief Manage all the highlights over scences
* 
* This class will manage all highlights on the scene by the number of scene
*/

public class NervesVisual: MonoBehaviour
{

    //public Dictionary<string, GameObject> availableHighlights;
    public Dictionary<GameObject, Material> HighlightsMaterials;

    public List<GameObject> availableHighlights;

    /// Material of inactive highlights
    public Material defaultMaterial;
    /// Material of active highlights
    private Material highlightMaterial;

    /*! Setup onEnable
    * 
    * Add EnableHighlights() to eventsystem when enabled
    * @see GuidedTourManager()
    */

    public void OnEnable()
    {
        GuidedTourManager.SetHighlights += EnableHighlights;
        GuidedTourManager.DisableHighlights += DisableAllHighlights;
    }
    /*! Setup OnDisable
    * 
    * Remove EnableHighlights() to eventsystem when enabled
    * @see GuidedTourManager()
    */
    public void OnDisable()
    {
        GuidedTourManager.SetHighlights -= EnableHighlights;
        GuidedTourManager.DisableHighlights -= DisableAllHighlights;
    }

    /*! Initialize list
   * 
   * Add all highlights in the hierarchy to the dictionary
*/
    public void Start()
    {
        //availableHighlights = new Dictionary<string, GameObject>();
        HighlightsMaterials = new Dictionary<GameObject, Material>();
        foreach (GameObject availableHighlght in availableHighlights) {
            HighlightsMaterials.Add(availableHighlght.gameObject, availableHighlght.gameObject.GetComponent<Renderer>().material);

        }

    }

    /*! \Manage labels on the scene
        * only activate specific highlights by the number of scene
        * @param names Names of fissures that should be shown on the scene
     */

    public void EnableHighlights(string[] names)
    {


        foreach (GameObject availableHighlight in availableHighlights)
        {
            availableHighlight.GetComponent<Renderer>().material = defaultMaterial;
        }

        foreach (string name in names)
        {
            foreach (GameObject availableHighlght in availableHighlights)
            {
                if (availableHighlght.name == name)
                {
                    highlightMaterial = HighlightsMaterials[availableHighlght];
                    availableHighlght.GetComponent<Renderer>().material = highlightMaterial;
                    Debug.Log("NERVES: enabling " + availableHighlght.name);
                }
            }
        }
    }

    public void DisableAllHighlights()
    {
        foreach (GameObject availableHighlight in availableHighlights)
        {
            availableHighlight.GetComponent<Renderer>().material = defaultMaterial;
        }
    }
}