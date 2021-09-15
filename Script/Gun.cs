using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 35f;
    public float range = 100f;
    public Camera cameraPoint;
    public ParticleSystem MuzzleFlash;
    public float fireRate = 15f;
    public int maxAmmo = 30;
    int currentAmmo;
    public float reloadTime = 1f;
    float nextTimeToFire = 0f;
    bool isReload;
    public Animator anmt;
    // Update is called once per frame
    void Start()
    {
        
        currentAmmo = maxAmmo;
    }
    void Update()
    {
        anmt.SetBool("isReload", isReload);
        if (isReload)
        {
            return;
        }
        if (currentAmmo <= 0f||Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(reload());
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)&&Time.time>=nextTimeToFire)
        {
            
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }
    IEnumerator reload()
    {
        isReload = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReload = false;
    }
    void Shoot()
    {
        
        RaycastHit col;
        MuzzleFlash.Play();
        if (Physics.Raycast(cameraPoint.transform.position, cameraPoint.transform.forward, out col, range))
        {
            Debug.Log(col.transform.name);
            currentAmmo--;
            MoveToPlayer z = col.transform.GetComponent<MoveToPlayer>();
            if (z != null)
            {
                z.isdead = true;
            }
            
            
        }
    }
}
