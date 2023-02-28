using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
[System.Serializable]
public class Boundary
{
    public float xmin, xmax, zmin, zmax;
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float nextFire;
    [SerializeField] int tilt;
    [SerializeField] private float fireRate;
    Rigidbody physic; 
    AudioSource audioPlayer;
    public Boundary boundary;
    public GameObject shot;
    public GameObject shotSpawn;
    void Start()
    {
        physic = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            audioPlayer.Play();
                
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        physic.velocity = movement*speed;

        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x, boundary.xmin, boundary.xmax),
            physic.position.y,
            Mathf.Clamp(physic.position.z, boundary.zmin, boundary.zmax));

        physic.position = position;
        physic.rotation= Quaternion.Euler(0,0,physic.velocity.x*tilt);
    }
}