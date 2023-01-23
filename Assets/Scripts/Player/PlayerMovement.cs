using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public Animator animatorController;
    public GameObject CarInPlayer;
    public GameObject YachtInPlayer;
    public GameObject CarInAre;
    public GameObject YachtInArea;
    public float playerSpeed = 5f;
    public float playerRotationSpeed = 10f;

    void Update()
    {
        Vector2 moveDirection = variableJoystick.Direction;
        Vector3 moveVector = new Vector3(moveDirection.x, 0, moveDirection.y);

        moveVector = moveVector * Time.deltaTime * playerSpeed;
        transform.position += moveVector;

        if (moveVector.magnitude != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveVector, Vector3.up), Time.deltaTime * playerRotationSpeed);
        }

        bool walking = moveDirection.magnitude > 0;
        animatorController.SetBool("WalkingAnim", walking);
        animatorController.SetFloat("SpeedAnim", moveDirection.magnitude);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            CarInPlayer.SetActive(true);
            CarInAre.SetActive(false);

        }

        if (other.CompareTag("Yacht"))
        {
            YachtInPlayer.SetActive(true);
            YachtInArea.SetActive(false);
        }
    }

    public void CarQuit()
    {
        CarInPlayer.SetActive(false);
        CarInAre.SetActive(true);
        this.transform.position = new Vector3(this.transform.position.x - 2, this.transform.position.y, this.transform.position.z-2);

    }

    public void YachtQuit()
    {
        YachtInPlayer.SetActive(false);
        YachtInArea.SetActive(true);
        this.transform.position = new Vector3(100, this.transform.position.y, -5);
    }
}
