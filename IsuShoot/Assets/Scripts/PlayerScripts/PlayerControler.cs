using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    private PhotonView _photonView;
    public Rigidbody rb;
    public ParticleSystem shootEffect;
    public float speed = 5f, superSpeed = 7, health = 100, range = 100f, jumtrustForce = 0.5f;
    private AudioSource fierSound;
    private int attackDamage = 25;
    public ParticleSystem leftTurbine;
    public ParticleSystem rightTurbine;
    public Transform groundedTransform;
    public RawImage FirstLife, SecondLife, ThirdLife, FourthLife;
    private AudioSource FlySound;

    private void Awake()
    {
        FlySound = gameObject.transform.GetChild(1).GetComponent<AudioSource>();

        _photonView = GetComponent<PhotonView>();

        rb = GetComponent<Rigidbody>();
        fierSound = gameObject.transform.GetComponent<AudioSource>();

        if (!_photonView.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (!_photonView.IsMine)
        {
            return;
        }

        MovePLayer();
    }

    private void Update()
    {
        if (!_photonView.IsMine)
        {
            return;
        }


        shoot();

        if (health == 75)
        {
            Destroy(FourthLife);
        }

        else if (health == 50)
        {
            Destroy(ThirdLife);
        }

        else if (health == 25)
        {
            Destroy(SecondLife);
        }

        else if (health == 0)
        {
            Destroy(FirstLife);
        }
    }

    private void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fierSound.Play();
            shootEffect.Play();

            Camera cam = transform.GetChild(0)?.GetComponent<Camera>();
            RaycastHit hit;
            Vector3 ShootPos = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            if (Physics.Raycast(ShootPos, cam.transform.forward, out hit, range))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    hit.collider.GetComponent<PlayerControler>().damage(attackDamage);
                }
            }
        }
    }

    public void damage(int damage)
    {
        _photonView.RPC("PunDamege", RpcTarget.All, damage);
    }

    [PunRPC]
    void PunDamege(int damage)
    {
        if (!_photonView.IsMine)
            return;

        health -= damage;
        if (health <= 0)
            PhotonNetwork.Destroy(gameObject);
    }


    private void MovePLayer()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.forward * superSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += -transform.forward * superSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.forward * speed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += -transform.right * superSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.right * speed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.right * superSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.right * speed * Time.deltaTime;
            }
        }

        if (Input.GetAxis("Jump") > 0f)
        {
            rb.AddForce(rb.transform.up * jumtrustForce, ForceMode.Impulse);
            leftTurbine.Play();
            rightTurbine.Play();

             if (!FlySound.isPlaying)
            {
                FlySound.Play();
            }
        }
            

        else if(Physics.Raycast(groundedTransform.position, Vector3.down, 0.05f, LayerMask.GetMask("Grounded")))
        {
            leftTurbine.Stop();
            rightTurbine.Stop();
            FlySound.Stop();
        }

        else
        {
            leftTurbine.Stop();
            rightTurbine.Stop();
            FlySound.Stop();
        }
    }
    

}    
