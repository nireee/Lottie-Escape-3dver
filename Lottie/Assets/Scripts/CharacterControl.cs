using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject player;
    public Animator characterAnimator;
    public Transform character;
    public Vector3 moveDirection;
    public float move_speed = 30f;
    public CharacterController cc;
    public float turn_speed = 45f;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movez = Input.GetAxis("Vertical");
        moveDirection = new Vector3(movex, 0.0f, movez);
        cc.Move(moveDirection * Time.deltaTime * move_speed);

        character.transform.forward = moveDirection;
        //var move_z = Vector3.forward * Input.GetAxisRaw("Vertical") * move_speed;
        characterAnimator.SetFloat("Speed", moveDirection.magnitude);
    }


}
