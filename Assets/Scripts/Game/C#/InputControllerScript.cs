using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class InputControllerScript : MonoBehaviour
{

    public float maxTime;
    public float minSwipeDist;

    public float startTime;
    public float endTime;

    public Vector3 startPos;
    public Vector3 endPos;
    public float swipeDistance;
    public float swipeTime;
    private void Start()
    {
        
    }

    void Update()
    {
       
            {
               
                if (Input.GetMouseButtonDown(0))
                {
                    startTime = Time.time;
                    startPos = Input.mousePosition;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    endTime = Time.time;
                    endPos = Input.mousePosition;

                    swipeDistance = (endPos - startPos).magnitude;
                    swipeTime = endTime - startTime;

                    if (swipeTime < maxTime && swipeDistance > minSwipeDist)
                    {
                        SwipeFunc();
                    }
                }
            }
        

        void SwipeFunc()
        {
            Vector2 distance = endPos - startPos;
            if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
            {
                
                if(endPos.x < startPos.x)
                {
                    Debug.Log("Left Swipe");
                    GameMasterScript.PlayerControler.MoveToLane(0);
                }
                else
                {
                    Debug.Log("Right Swipe");
                    GameMasterScript.PlayerControler.MoveToLane(1);
                }
            }
            else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
            {
                Debug.Log(" vertical  swipe");
                GameMasterScript.PlayerControler.JumpAction();
            }
        }
    }

}

    

