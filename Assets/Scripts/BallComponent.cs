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
        SizeDown,
        SizeUp
    }

    public float Speed = 1.0f;

    public List<BallInstruction> Instructions = new List<BallInstruction>();
    
    private int CurrentInstruction = 0;
    private float Distance = 0.0f;  
    public float InstructionLenght = 3.0f;
    
    private Vector3 vecRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CurrentInstruction < Instructions.Count)
        {
            
            float RealSpeed = Speed * Time.deltaTime;
            Distance += RealSpeed;

            switch (Instructions[CurrentInstruction])
            {
                case BallInstruction.MoveUp:
                    transform.position += Vector3.up * RealSpeed;
                    break;

                case BallInstruction.MoveDown:
                    transform.position += Vector3.down * RealSpeed;
                    break;

                case BallInstruction.MoveLeft:
                    transform.position += Vector3.left * RealSpeed;
                    break;

                case BallInstruction.MoveRight:
                    transform.position += Vector3.right * RealSpeed;
                    break;

                case BallInstruction.SizeUp:
                    transform.localScale += Vector3.one * RealSpeed;
                    break;

                case BallInstruction.SizeDown:
                    if (transform.localScale.x > 0)
                    {
                        transform.localScale -= Vector3.one * RealSpeed;
                    }

                    break;

                // Obrot o 180 stopni
                case BallInstruction.TurnLeft:
                    vecRotation += RealSpeed * new Vector3(0, -60, 0);
                    transform.rotation = Quaternion.Euler(vecRotation);
                    break;

                case BallInstruction.TurnRight:
                    vecRotation += RealSpeed * new Vector3(0, 60, 0);
                    transform.rotation = Quaternion.Euler(vecRotation);
                    break;

                default:
                    Debug.Log("Idle");
                    break;
            }

            if (Distance > InstructionLenght)
            {
                Distance = 0.0f;
                ++CurrentInstruction;
            }

         
        }
    }

    }





