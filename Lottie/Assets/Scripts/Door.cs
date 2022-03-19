using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool key;
    public GameObject door;
    public Animator ani;
    public GameObject opendoor;
    public bool HasOpened;
    public GameObject hint;
    public GameObject key_item;
    public Transform display_key;
    public GameObject panel;
    public float cur_time;
    // Start is called before the first frame update
    void Start()
    {
        opendoor.SetActive(false);
        hint.SetActive(false);
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(key_item.activeSelf == false)
        {
            key = true;
        }

        if (key)
        {
            if(opendoor.activeSelf == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    key_item.SetActive(true);
                    key_item.transform.position = display_key.position;
                    //ani.Play("KeyRotate");
                    ani.Play("OpenDoor");
                    key_item.SetActive(false);

                    cur_time = Time.time;

                }
                
            }
            
        }

        if (Time.time > cur_time + 3f && cur_time != 0)
        {
            panel.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (key)
            {
                opendoor.SetActive(true);
            }
            else
            {
                hint.SetActive(true);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        opendoor.SetActive(false);
        hint.SetActive(false);
    }

}
