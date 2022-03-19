using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chest;
    public Animator ani;
    public GameObject panel;
    public GameObject Instruction;
    public bool open;
    public bool Key;
    public GameObject key;
    public bool HasOpened;
    //public Transform showKey;
    // Start is called before the first frame update
    void Start()
    {
        Instruction.SetActive(false);
        panel.SetActive(false);
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
                    open = true;
                    Instruction.SetActive(false);
                }
            }
            if (open)
            {
                ani.Play("OpenDrawer");
                panel.SetActive(true);
                if (panel.activeSelf)
                {
                    Key = true;
                    open = false;
                    //key.transform.position = showKey.position;
                    HasOpened = true;
                }

            }
        }
        if (Input.GetKey(KeyCode.P) && HasOpened)
        {
            key.SetActive(false);
            panel.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instruction.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Instruction.SetActive(false);

    }


}
