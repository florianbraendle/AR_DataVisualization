using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_Raycast_object_placement : MonoBehaviour
{
    public GameObject object_to_activate;
    public TMP_Text placement_hint_text;

    bool object_activated;
    ARRaycastManager arraycastman;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();


    // Start is called before the first frame update
    void Start()
    {
        object_activated = false;
        arraycastman = GetComponent<ARRaycastManager>();
        placement_hint_text.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (arraycastman.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitpose = hits[0].pose;
                if (!object_activated)
                {
                    object_to_activate.transform.position = hitpose.position;
                    object_to_activate.transform.rotation = hitpose.rotation;
                    object_to_activate.SetActive(true);
                    object_activated = true;
                    placement_hint_text.gameObject.SetActive(false);

                    // remove planePrefab
                    GetComponent<ARPlaneManager>().SetTrackablesActive(false);
                    GetComponent<ARPlaneManager>().planePrefab.SetActive(false);
                }
            }
        }
    }
}
