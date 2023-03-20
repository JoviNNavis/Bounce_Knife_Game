using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    public bool belowlevel5;
    public bool spikelevel;
    //public Color before_color1, before_color2;
    //public Color after_color1, after_color2;
    public Color up_color_level5, down_color_level5;
    public Color up_color_level1, down_color_level1;
    public Material up, down;
    public Material spikemat;
    public Color beforecolor, aftercolor;

    void Start()
    {
        up_color_level5 = new Color32(223,144,82,255);
        down_color_level5 = new Color32(231, 121, 8, 255);
        up_color_level1 = new Color32(236, 240, 241, 255);
        down_color_level1 = new Color32(128, 128, 128, 255);
        beforecolor = new Color32(255, 0, 0, 180);
        aftercolor = new Color32(168, 255, 133, 180);
        spikemat.color = beforecolor;
        spikelevel = false;
    }

   
    void Update()
    {
        if (belowlevel5)
        {
            up.color = up_color_level1;
            down.color = down_color_level1;
        }
        else
        {
            up.color = up_color_level5;
            down.color = down_color_level5;
        }
    }
}
