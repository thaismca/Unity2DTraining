using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    //setting starting max an min guesses
    int maxGuess;
    int minGuess;

    //random guess generator
    System.Random r = new System.Random();
    int guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //if player presses down arrow key, it means the number picked is lower than my guess
            //so all my next guesses won't make sense being higher than the current one
            //that means the maxGuess should be replaced by this last guess attempt
            maxGuess = guess;
            NextGuess();
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //if player presses up arrow key, it means the number picked is higher than my guess
            //so all my next guesses won't make sense being lower than the current one
            //that means the minGuess should be replaced by this last guess attempt
            minGuess = guess;
            NextGuess();
        }
        
        //if enter key is pressed, it means my guess was right - yay!
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Yay!");
            StartGame();
        }
            
    }

    void StartGame()
    {
        maxGuess = 1000;
        minGuess = 1;

        //instructions printed in the console to the player
        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("Pick a number, don't tell me what it is.");
        Debug.Log("Highest number you can pick is " + maxGuess);
        Debug.Log("Lowest number you can pick is " + minGuess);
        Debug.Log("Okay, now I'll start to try guessing the number you pick.");
        Debug.Log("Press down key if the number you picked is lower than my guess.");
        Debug.Log("Press up key if the number you picked is higher than my guess.");
        Debug.Log("Press enter key if I guess it correctly.");

        //first guess
        guess = r.Next(minGuess, maxGuess + 1);
        Debug.Log("Is you number higher or lower than " + guess);
    }

    void NextGuess()
    {
        //generate a new random guess considering the new max or min value based on the user feedback
        guess = r.Next(minGuess, maxGuess + 1);
        Debug.Log("Is you number higher or lower than " + guess);
    }

}
