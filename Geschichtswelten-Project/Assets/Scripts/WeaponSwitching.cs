using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    
    void Start()
    {
        SelectWeapon();
    }

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    public void Switch()
    {
        if (selectedWeapon >= transform.childCount - 1)
        {
            selectedWeapon = 0;
        }
        else
        {
            selectedWeapon++;
        }
        SelectWeapon();
    }
}
