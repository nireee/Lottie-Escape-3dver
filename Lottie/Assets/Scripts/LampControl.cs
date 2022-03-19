using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampControl : MonoBehaviour
{
    public bool LightOn;
    public Animator LightCC;
    public GameObject Instruction;
    public GameObject ll;

    public bool HasOpened;
    // Start is called before the first frame update
    void Start()
    {
        Instruction.SetActive(false);
        LightOn = false;
        ll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!HasOpened)
        {
            if (Instruction.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    LightOn = true;
                }
            }
            if (LightOn)
            {
                LightCC.Play("LightOnAni");
                ll.SetActive(true);
                HasOpened = true;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!HasOpened)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Collide!");
                Instruction.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Instruction.SetActive(false);
    }


}
