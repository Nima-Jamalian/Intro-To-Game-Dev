using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroToProgramming : MonoBehaviour
{
    //Declaring Variables
    //VaubleType GiveItAName = Value
    int myAge = 28;
    float myHeight = 183.5f;
    string myName = "Nima";
    bool isPlayerAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        //If statement
        if (isPlayerAlive == true)
        {
            PlayerStatus();
        } else
        {
            Debug.Log("Game Over");
        }

        Debug.Log(PlayerAge());
        Debug.Log(Addition(100, 500));
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Declaring Method
    //typeOfMethod MethodName(MethodInputs){
    //}
    //Write a method and prints player information
    void PlayerStatus()
    {
        Debug.Log("My age is: " + myAge);
        Debug.Log("My Height is: " + myHeight);
        Debug.Log("My Name is: " + myName);
        Debug.Log("Is Player Alive: " + isPlayerAlive);
    }

    //Wrtire a method that return player age
    int PlayerAge()
    {
        return myAge;
    }

    /*
    * Write a mthod that take two numbers as method input
    * The function should add two numbers together 
    * return the final value
    */
    int Addition(int value1, int value2)
    {
        return value1 + value2;
    }

}