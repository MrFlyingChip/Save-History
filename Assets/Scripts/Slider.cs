using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour {

    public GameObject[] content;
    bool LerpH;
    ScrollRect scroll;

    // Use this for initialization
    void Start () {
        scroll = gameObject.GetComponent<ScrollRect>();
        scroll.inertia = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (LerpH)
        {
            
        }
    }
}
