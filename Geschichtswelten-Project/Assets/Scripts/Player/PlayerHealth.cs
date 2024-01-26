using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public int maxHealth = 5;

    public Image overlay;
    public float duration;
    public float fadeSpeed;
    private float durationTimer;
    [SerializeField] private bool isHealing;
    private bool cannotHealHealth;
    private Player playerScript;

    public Vector3 respawnPosition; //this will always be set to the most recent respawn point that the player crossed

    private CameraShakeController cameraShakeScript;

    void Start()
    {
        currentHealth = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        cameraShakeScript = GetComponent<CameraShakeController>();
        playerScript = gameObject.GetComponent<Player>();
        respawnPosition = gameObject.transform.position; //setting the first respawn position to be the initial spawn position
    }

    void Update()
    {
        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            //Debug.Log(durationTimer);
            if (isHealing)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }

        if (overlay.color.a == 0)
        {
            isHealing = false;
        }
    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            Debug.Log("should respawn");
            HealHealth();
            Respawn();
            //SceneManager.LoadScene("Death Screen");
        }

        durationTimer = 0;
        switch (currentHealth)
        {
            case 1:
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1f);
                break;
            case 2:
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.75f);
                break;
            case 3:
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.5f);
                break;
            case 4:
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.25f);
                break;
        }

        if (!cannotHealHealth)
        {
            cannotHealHealth = true;
            Invoke("HealHealth", 20f);
        }
        cameraShakeScript.TakeDamage();
    }


    private void HealHealth()
    {
        isHealing = true;
        currentHealth = maxHealth;
        cannotHealHealth = false;
        Invoke("SetToNull", 0.2f);
    }

    private void SetToNull()
    {
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0f);
    }

    private void Respawn()
    {
        Debug.Log("Respawning");
        //source: https://forum.unity.com/threads/does-transform-position-work-on-a-charactercontroller.36149/ The character controller doesn't like you to change the position externally, apparently
        playerScript.DisableCharacterController();
        gameObject.transform.position = respawnPosition;
        //gameObject.transform.rotation = respawnPoint.rotation; //does not work, as mentioned on the forum linked above but not setting the rotation should be fine anyways
        playerScript.EnableCharacterController();
    }
}