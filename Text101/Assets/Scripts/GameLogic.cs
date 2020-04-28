using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;

    // Start is called before the first frame update
    void Start()
    {
        //initialize game with the first state in our adventure
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        //calling method that responds when player presses a key to make a choice
        ManageState();

        //calling method to quit game when player presses Q
        QuitGame();
    }


    //method to respond to player's choice
    private void ManageState()
    {
        //store the next states related to the current state of the adventure
        var nextStates = state.GetNextStates();

    //iterates through the existing next states for the current state
    for (int index = 0; index < nextStates.Length; index++)
    {
      if (Input.GetKeyDown(KeyCode.Alpha1 + index))
      {
        //set new current state to the state in option corresponding to the key pressed
        state = nextStates[index];
      }
    }

        //set the text in the Text Component of the game object StoryText to match the text of the chosen state
        //so the text related to the new current state can be displayed to player
        textComponent.text = state.GetStateStory();
    }

    private void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
    }
  }
}
