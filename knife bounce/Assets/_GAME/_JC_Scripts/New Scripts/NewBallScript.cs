using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBallScript : MonoBehaviour
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
            if (FindObjectOfType<Ballpowerup>().time < 0.3f)
            {
                //float _newUpforce = upForce + 150;
                //Rb.AddForce(transform.up * _newUpforce, ForceMode.Force);
                Rb.AddForce(transform.up * upForce, ForceMode.Force);
                Rb.mass = 0.7f;
                powerup_mode = true;
                RenderSettings.skybox = skybox2;
                tail.enabled = false;
                _fire.Play();
                //FindObjectOfType<ColorScript>().up.color = FindObjectOfType<ColorScript>(). after_color1;
                //FindObjectOfType<ColorScript>(). down.color = FindObjectOfType<ColorScript>().after_color2;
                //FindObjectOfType<ColorScript>().spikemat.color = FindObjectOfType<ColorScript>().spike_powermode;

            }
            else
            {
                _fire.Pause();
                _fire.Clear();

                powerup_mode = false;
                RenderSettings.skybox = skybox;
                Rb.mass = 1f;

                Rb.AddForce(transform.up * upForce, ForceMode.Force);
                // FindObjectOfType<ColorScript>().up.color = FindObjectOfType<ColorScript>().before_color1;
                // FindObjectOfType<ColorScript>().down.color = FindObjectOfType<ColorScript>().before_color2;
                // FindObjectOfType<ColorScript>().spikemat.color = FindObjectOfType<ColorScript>().beforespikemode;

                //     FindObjectOfType<Knife_anim_controller>().spike.material.color = FindObjectOfType<Knife_anim_controller>().beforeSpikecolor;

            }
        }

        if (collision.gameObject.CompareTag("End"))
        {
            Debug.Log("U R DEAD");
        }
    }
}
