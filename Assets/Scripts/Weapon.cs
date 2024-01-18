using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //parameters
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 33f;
    [SerializeField] float coolDownTimer = 0.5f;


    //cached refs
    [SerializeField] Camera playerCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVFX;
    public float maxAmmo;
    public float currentAmmo;
    public float magSize;
    public float currentMag;

    private UIManager UIManager;

    [Header("Keybinds")]
    public KeyCode reloadKey = KeyCode.R;

    bool canShoot = true;


    private void OnEnable()
    {
        canShoot = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        currentMag = magSize;

        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        UIManager.UpdateAmmo(currentAmmo);
        UIManager.UpdateMag(currentMag);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }

        if(Input.GetKeyDown(reloadKey) && currentAmmo > 0)
        {
            Reload();
        }

        UIManager.UpdateAmmo(currentAmmo);
        UIManager.UpdateMag(currentMag);
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        //if(ammo.GetAmmoAmount(ammoType) > 0)
        //{
            //ProcessRayCast();
            //PlayMuzzleFlash();
            //ammo.ReduceAmmo(ammoType);
        //}

        if (currentMag > 0)
        {
            ProcessRayCast();
            PlayMuzzleFlash();
            currentMag--;
            UIManager.UpdateMag(currentMag);
        }

        yield return new WaitForSeconds(coolDownTimer);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();  
    }

    private void ProcessRayCast()
    {
        RaycastHit thingWeHit;
        
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out thingWeHit, range))
        {
            //CreateHitVFX(thingWeHit);
            EnemyHealth Target = thingWeHit.transform.GetComponent<EnemyHealth>();
            if (Target == null) { return; }
            Target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    //private void CreateHitVFX(RaycastHit thingWeHit)
    //{
        //GameObject impact = Instantiate(hitVFX, thingWeHit.point, Quaternion.identity);
        //GameObject impact = Instantiate(hitVFX, thingWeHit.point, Quaternion.LookRotation(thingWeHit.normal));
        //Destroy(impact, 0.1f);
    //}

    private void Reload()
    {
        if (currentAmmo > 0 && currentMag < magSize)
        {
            currentMag = magSize;
            currentAmmo -= magSize;
            UIManager.UpdateAmmo(currentAmmo);
            UIManager.UpdateMag(currentMag);
        }
        else
            CannotReload();
        
    }

    private void CannotReload()
    {
        print("Cannot Reload");
    }

    public void AmmoPickUp()
    {
        currentAmmo = maxAmmo;
        UIManager.UpdateAmmo(currentAmmo);
    }
}
