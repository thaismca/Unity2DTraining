using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    //setting starting max an min guesses
    int maxGuess = 1000;
    int minGuess = 1;

    //random guess generator
    System.Random r = new System.Random();
    int guess;

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        //if player presses down arrow key, it means the number picked is lower than my guess
        //so all my next guesses won't make sense being higher than the current one
        //that means the maxGuess should be replaced by this last guess attempt
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            maxGuess = guess;
            guess = r.Next(minGuess, maxGuess + 1);
            Debug.Log("Is you number higher or lower than " + guess);
        }

        //if player presses up arrow key, it means the number picked is higher than my guess
        //so all my next guesses won't make sense being lower than the current one
        //that means the minGuess should be replaced by this last guess attempt
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            minGuess = guess;
            guess = r.Next(minGuess, maxGuess + 1);
            Debug.Log("Is you number higher or lower than " + guess);
        }
        
        //if enter key is pressed, it means my guess was right - yay!
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Yay!");
        }
            
    }
}
