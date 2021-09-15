using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Complete : MonoBehaviour
{
    public Text levelpass;
    // Start is called before the first frame update
    void Start()
    {
        levelpass.text = "Mission: Get out there!!";
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            levelpass.text = "Complete!! You are safe now!!";
            levelpass.color = Color.green;
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            levelpass.text = "Complete!! You are safe now!!";
            levelpass.color = Color.green;
        }
    }
}
