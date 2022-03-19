using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{
    public GameObject player;
    public Animator characterAnimator;
    public Transform character;
    public Vector3 moveDirection;
    public float move_speed = 30f;
    public CharacterController cc;
    public float turn_speed = 720f;

    


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movez = Input.GetAxis("Vertical");
        moveDirection = new Vector3(movex, 0.0f, movez);
        moveDirection.Normalize();
        //character.rotation = Quaternion.Slerp(character.rotation, Quaternion.LookRotation(moveDirection), turn_speed);
        cc.Move(moveDirection * Time.deltaTime * move_speed);
        //character.Translate(moveDirection * move_speed * Time.deltaTime);


        if (moveDirection != Vector3.zero)
        {
            Quaternion rotateDir = Quaternion.LookRotation(moveDirection, Vector3.up);
            character.rotation = Quaternion.RotateTowards(character.rotation, rotateDir, turn_speed * Time.deltaTime);
        }
        characterAnimator.SetFloat("Speed", moveDirection.magnitude);


        if (Input.GetKey(KeyCode.Escape))
        {
            ReLoadScene();
        }
    }

    public void ReLoadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


}
