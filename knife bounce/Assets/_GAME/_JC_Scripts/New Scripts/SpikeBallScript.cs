using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallScript : MonoBehaviour
{
    public float upForce;
    public bool powerup_mode;

    public ParticleSystem _fire;
    public Material skybox;
    public Material skybox2;
    public TrailRenderer tail;
    private Rigidbody Rb;

    void Start()
    {
        RenderSettings.skybox = skybox;
      
       
        Rb = GetComponent<Rigidbody>();
        _fire.Pause();
        _fire.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Rb.AddForce(transform.up * upForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Knife") || collision.gameObject.CompareTag("DKnife"))
        {
            if (FindObjectOfType<Ballpowerup>().time < 0.35f)
            {
                FindObjectOfType<ButtonManager>().changecolor = true;

                float _newUpforce = upForce + 150;
                Rb.AddForce(transform.up * _newUpforce, ForceMode.Force);
                powerup_mode = true;
                RenderSettings.skybox = skybox2;
                tail.enabled = false;
                _fire.Play();
                //FindObjectOfType<ColorScript>().up.color = FindObjectOfType<ColorScript>(). after_color1;
                //FindObjectOfType<ColorScript>(). down.color = FindObjectOfType<ColorScript>().after_color2;
             FindObjectOfType<ColorScript>().spikemat.color = FindObjectOfType<ColorScript>().aftercolor;

            }
            else
            {
                _fire.Pause();
                _fire.Clear();

                powerup_mode = false;
                FindObjectOfType<ButtonManager>().changecolor = false;

                RenderSettings.skybox = skybox;
                Rb.AddForce(transform.up * upForce, ForceMode.Force);
                //FindObjectOfType<ColorScript>().up.color = FindObjectOfType<ColorScript>().before_color1;
                //FindObjectOfType<ColorScript>().down.color = FindObjectOfType<ColorScript>().before_color2;
                FindObjectOfType<ColorScript>().spikemat.color = FindObjectOfType<ColorScript>().beforecolor;

                //    FindObjectOfType<Knife_anim_controller>().spike.material.color = FindObjectOfType<Knife_anim_controller>().beforeSpikecolor;

            }
        }

        if (collision.gameObject.CompareTag("End"))
        {
            Debug.Log("U R DEAD");
        }
    }
}
