using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region UI

    [Header("UI Variables")] [SerializeField] private TextMeshProUGUI ammoCount;
    [SerializeField] private GameObject hitMarkerUI;
    [SerializeField] private GameObject crosshairUI;

    #endregion

    #region Variables_Aim and_Shoot

    //Shooting Variables
    [Header("Shooting Variables")] public float damage;
    public float timeBetweenShooting;
    public float spread;
    public float range;
    public float maxReload;
    public float ammo;
    public float maxAmmo;
    public float ammoPicked;
    public float reloadTime;
    private bool _isReloading;
    private bool isRecoiling;

    //Aiming Variables
    [Header("Aiming Variables")] public Vector3 normalPose;
    public Vector3 aimPose;
    public float aimSpeed;
    public bool isAiming = false;

    #endregion

    #region Sounds
    [SerializeField] private AudioSource generalAudioSource;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioClip shootingSound;
    #endregion
    #region OtherVariables

    [Header("Other Variables")] public bool isShooting;
    public ParticleSystem flash;
    public Animator animator;
    public Camera cam;
    public CinemachineVirtualCamera POV_cam;
    public GameObject crosshair;
    [SerializeField] private PauseMenu PauseMenu;
    #endregion
    
    

    // Start is called before the first frame update
    void Start()
    {
        ammoCount.text = ammo + "/10";
        hitMarkerUI.gameObject.SetActive(false);
        crosshairUI.gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        
        //transform.position = cam.transform.position;
        ammoCount.text = ammo + "/" + maxAmmo;
        if (isAiming)
        {
            StartAiming();
        }
        else if (!isAiming)
        {
            StopAiming();
        }
    }

    #region Shooting

    public void Shoot()
    {
        if (PauseMenu.isPaused)
        {
            return;
        }
        if (ammo > 0 && isShooting == false && isRecoiling == false)
        {
            isShooting = true;
            ammo--;
            Invoke("ResetShot", timeBetweenShooting);
            generalAudioSource.PlayOneShot(shootingSound, Random.Range(0.7f, 1.0f));
            flash.Play();
            StartCoroutine(Recoil());

            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);
            Vector3 direction = cam.transform.TransformDirection(Vector3.forward) + new Vector3(x, y, 0);

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, direction, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Enemy target = hit.transform.GetComponent<Enemy>();
                if (target != null)
                {
                    hitActive();
                    Invoke("hitDisable", 0.2f);
                    target.TakeDamage(damage);
                }
            }
        }
    }

    IEnumerator Reloading()
    {
        _isReloading = true;
    
        animator.SetBool("Reloading", true);
        
        generalAudioSource.PlayOneShot(reloadSound);

        yield return new WaitForSeconds(reloadTime - 0.25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(0.25f);

        if (maxAmmo >= maxReload || ammo + maxAmmo >= maxReload)
        {
            maxAmmo -= (maxReload - ammo);
            ammo = maxReload;
        }
        else
        {
            ammo += maxAmmo;
            maxAmmo = 0;
        }

        ammoCount.text = ammo + "/10";
        _isReloading = false;
    }

    IEnumerator Recoil()
    {
        isRecoiling = true;
        
        animator.SetBool("Shooting", true);

        yield return new WaitForSeconds(0.05f);

        animator.SetBool("Shooting", false);
        
        yield return new WaitForSeconds(0.05f);

        isRecoiling = false;
    }

    public void Reload()
    {
        if (_isReloading == false && maxAmmo > 0 && ammo < maxReload)
        {
            StartCoroutine(Reloading());
        }
    }

    public void pickAmmo()
    {
        maxAmmo += ammoPicked;
    }

    public void ResetShot()
    {
        isShooting = false;
    }

    private void OnEnable()
    {
        _isReloading = false;
        isShooting = false;
        isRecoiling = false;
        isAiming = false;
        animator.SetBool("Reloading", false);
        animator.SetBool("Shooting", false);
    }

    private void hitActive()
    {
        crosshairUI.gameObject.SetActive(false);
        hitMarkerUI.gameObject.SetActive(true);
    }

    private void hitDisable()
    {
        crosshairUI.gameObject.SetActive(true);
        hitMarkerUI.gameObject.SetActive(false);
    }

    #endregion


    #region Aiming

    public void StartAiming()
    {
        isAiming = true;
        transform.localPosition = Vector3.Slerp(transform.localPosition, aimPose, aimSpeed * Time.deltaTime);
        POV_cam.m_Lens.FieldOfView -= 200 * Time.deltaTime;
        POV_cam.m_Lens.FieldOfView = Mathf.Clamp(POV_cam.m_Lens.FieldOfView, 30, 60);
        crosshair.SetActive(false);
    }

    public void StopAiming()
    {
        isAiming = false;
        transform.localPosition = Vector3.Slerp(transform.localPosition, normalPose, aimSpeed * Time.deltaTime);
        POV_cam.m_Lens.FieldOfView += 200 * Time.deltaTime;
        POV_cam.m_Lens.FieldOfView = Mathf.Clamp(POV_cam.m_Lens.FieldOfView, 30, 60);
        crosshair.SetActive(true);
    }

    #endregion
}