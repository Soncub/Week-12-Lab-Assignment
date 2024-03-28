using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptThree : MonoBehaviour
{
    char[] values = new char[] {
        'K',
        'Q',
        'J',
        'A'
    };

    char[] suits = new char[]{
        'S',
        'H',
        'D',
        'C'
    };
    List<string> generatedCards = new List<string>();
    List<string> cards = new List<string>();
    List<string> currentHand = new List<string>();

    void Start()
    {
        Debug.Log("The suit icons were not able to be added in the code, so S = Spades, H = Hearts, D = Diamonds, and C = Clubs.");

        foreach(char value in values) 
        {
            foreach (char suit in suits)
            {
                string result = "";
                result += value;
                result += suit;
                generatedCards.Add(result);
            }
        }
        cards = new List<string>(generatedCards.ToArray());
        
        for (int i = 0; i < 4; i++){
            
            currentHand.Add(GetCard());
        }

        bool hasWon = false;
        while(cards.Count >0){

            if (CheckIfWin()) {
                hasWon = true;
                break;
            }

            currentHand.RemoveAt(Random.Range(0, 4));
            currentHand.Add(GetCard());
        }

        if(!hasWon) Debug.Log("You Lose.");
    }

    string GetCard(){
            int id = Random.Range(0, cards.Count);
            string result = cards[id];
            cards.RemoveAt(id);
            return result;
    }




    bool CheckIfWin(){

        int spades = 0;
        int hearts = 0;
        int diamonds = 0;
        int clubs = 0;

        foreach (string card in currentHand)
        {
            if(card[1] == 'S') spades++;
            if(card[1] == 'H') hearts++;
            if(card[1] == 'D') diamonds++;
            if(card[1] == 'C') clubs++;
        }

        bool hasWon = spades > 2 || hearts > 2 || diamonds > 2 || clubs > 2;

        string hasWonString = hasWon? "The game is WON." : "This is not a winning hand.";
        Debug.LogFormat("I made the initial deck and draw. My hand is: {0}, {1}, {2}, {3}. {4}", currentHand[0], currentHand[1], currentHand[2], currentHand[3], hasWonString);

        return hasWon;


    }

}
