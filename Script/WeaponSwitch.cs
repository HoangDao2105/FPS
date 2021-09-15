using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int WeaponSelected=0;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int preWeapon = WeaponSelected;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponSelected = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&&transform.childCount-1>=1)
        {
            WeaponSelected = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount - 1 >= 2)
        {
            WeaponSelected = 2;
        }
        if (preWeapon != WeaponSelected)
        {
            SelectWeapon();
        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform item in transform)
        {
            if (i == WeaponSelected)
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
            i++;
        }

    }
}
