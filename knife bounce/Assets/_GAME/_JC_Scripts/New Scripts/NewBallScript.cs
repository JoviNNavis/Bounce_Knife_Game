using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBallScript : MonoBehaviour
{
    public float upForce;

    public bool powerup_mode;
    private MeshRenderer water,water1;
    public ParticleSystem _fire;
    public Material skybox;
    public Material skybox2;
    public bool islevelcompleted;
    public bool changecolor;
    public TrailRenderer tail;
    private Rigidbody Rb;
    private MeshRenderer _knife;
  public   Color _blue;
  public Color purple;
    int num,max;
    void Start()
    {
      
        RenderSettings.skybox = skybox;
        water = FindObjectOfType<ButtonManager>().water;
        _blue = new Color32(0, 137, 255,255);
        purple = new Color32(0, 1, 255,255);
        Rb = GetComponent<Rigidbody>();
        _fire.Pause();
        _fire.Clear();
        water.material.SetColor("_BaseColor", _blue);
        changecolor = false;
    }

    // Update is called once per frame
    void Update()
    {

      
         if(Input.GetButtonDown("Jump"))
        {
            Rb.AddForce(transform.up * upForce);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
          
        }
        if (changecolor)
        {
           
        }
    }


    public void stopwatercolor()
    {
        if (islevelcompleted)
        {
            water.material.SetColor("_BaseColor", _blue);
            RenderSettings.skybox = skybox;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Knife") || collision.gameObject.CompareTag("DKnife"))
        {
            if (FindObjectOfType<Ballpowerup>().time < 0.3f)
            {

              FindObjectOfType<ButtonManager>().changecolor = true;
              
                float _newUpforce = upForce + 150;
       
                water.material.SetColor("_BaseColor", purple);


                Rb.AddForce(transform.up * _newUpforce, ForceMode.Force);
               
              if(FindObjectOfType<ColorScript>().spikelevel)
                {
                    FindObjectOfType<Starf1>().inpowermode = true;
                }
                powerup_mode = true;
                RenderSettings.skybox = skybox2;
        
                _fire.Play();
                //FindObjectOfType<ColorScript>().up.color = FindObjectOfType<ColorScript>(). after_color1;
                //FindObjectOfType<ColorScript>(). down.color = FindObjectOfType<ColorScript>().after_color2;
                // FindObjectOfType<ColorScript>().spikemat.color = FindObjectOfType<ColorScript>().spike_powermode;
                FindObjectOfType<ColorScript>().spikemat.color = FindObjectOfType<ColorScript>().aftercolor;

            }
            else
            {
                _fire.Pause();
                _fire.Clear();

                powerup_mode = false;
                FindObjectOfType<ButtonManager>().changecolor = false;

                if (FindObjectOfType<ColorScript>().spikelevel)
                {
                    FindObjectOfType<Starf1>().inpowermode = false;
                }
            
                RenderSettings.skybox = skybox;
                Rb.mass = 1f;
                water.material.SetColor("_BaseColor", _blue);
                //FindObjectOfType<KnifePrefabScript>().nonpowermaterial();
                changecolor = false;

                Rb.AddForce(transform.up * upForce, ForceMode.Force);
                // FindObjectOfType<ColorScript>().up.color = FindObjectOfType<ColorScript>().before_color1;
                // FindObjectOfType<ColorScript>().down.color = FindObjectOfType<ColorScript>().before_color2;
                // FindObjectOfType<ColorScript>().spikemat.color = FindObjectOfType<ColorScript>().beforespikemode;
                FindObjectOfType<ColorScript>().spikemat.color = FindObjectOfType<ColorScript>().aftercolor;
                //     FindObjectOfType<Knife_anim_controller>().spike.material.color = FindObjectOfType<Knife_anim_controller>().beforeSpikecolor;

            }
        }

        if (collision.gameObject.CompareTag("End"))
        {
            Debug.Log("U R DEAD");
        }
    }
}
