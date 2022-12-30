using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BallComponent : MonoBehaviour
{

   public enum BallInstruction
    {
        Idle = 0,
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        TurnLeft,
        TurnRight,
        ReduceSize,
        IncreaseSize

    }

    public float Speed = 1.0f;
    public float rotationSpeed = 100.0f;
    private Vector3 vecRotation = Vector3.zero;

    public BallInstruction Instruction = BallInstruction.Idle;

    

    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
     
        switch (Instruction)
        {
            case BallInstruction.MoveUp:
                transform.position += Speed * Time.deltaTime * new Vector3(0, 1, 0);
                break;

            case BallInstruction.MoveDown:
                transform.position += Speed * Time.deltaTime * new Vector3(0, -1, 0);
                break;

            case BallInstruction.MoveLeft:
                transform.position += Speed * Time.deltaTime * new Vector3(-1, 0, 0);
                break;

            case BallInstruction.MoveRight:
                transform.position += Speed * Time.deltaTime * new Vector3(1, 0, 0);
                break;

            case BallInstruction.TurnLeft:
                vecRotation += rotationSpeed * Time.deltaTime * new Vector3(0, -1, 0);
                transform.rotation = Quaternion.Euler(vecRotation);
                break;

            case BallInstruction.TurnRight:
                vecRotation += rotationSpeed * Time.deltaTime * new Vector3(0, 1, 0);
                transform.rotation = Quaternion.Euler(vecRotation);
                break;

            case BallInstruction.IncreaseSize:
                transform.localScale += Speed * Time.deltaTime * new Vector3(1, 1, 1);
                break;

            case BallInstruction.ReduceSize:
                if (transform.localScale.x > 0)
                {
                    transform.localScale -= Speed * Time.deltaTime * new Vector3(1, 1, 1);
                }
                
                break;
             
            default:
                Debug.Log("Idle");
                break;
        }

    }




}
