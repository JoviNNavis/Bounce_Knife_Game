using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    //public Color before_color1, before_color2;
    //public Color after_color1, after_color2;
    public Color beforespikemode, spike_powermode;
    //public Material up, down;
    public Material spikemat;
    void Start()
    {
        //up.color = before_color1;
        //down.color = before_color2;
        spikemat.color = beforespikemode;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
