using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardQue : MonoBehaviour
{

    //spaced reptitin pattern 1>7>16 : use the same ration
    public float goodSpacing = 960;
    public float medSpacing = 420;
    public float badSpacing = 60;

    public TextMeshProUGUI displayText;
    public TextMeshProUGUI progressText;

    public GameObject bg;
    public GameObject done;
    public GameObject rating;
    public GameObject mainButton;
    public GameObject testCard;

    public GameObject person;
    public Transform spawn;

    float[] spacedReps;
    public List<int> CompletedCards = new List<int>();

    public float startTime;

    private void Awake()
    {
        spacedReps = new float[GetCard.cardFront.Length];
        for (int i = 0; i < GetCard.cardFront.Length; i ++)
        {
            int random = Random.Range(0, GetCard.cardFront.Length);

            string f_temporary = GetCard.cardFront[random];
            string b_temporary = GetCard.cardBack[random];

            GetCard.cardFront[random] = GetCard.cardFront[i];
            GetCard.cardFront[i] = f_temporary;
            GetCard.cardBack[random] = GetCard.cardBack[i];
            GetCard.cardBack[i] = b_temporary;
        }

        //make sure things r being randomized
        for (int i = 0; i < GetCard.cardFront.Length; i++)
        {
            Debug.Log(GetCard.cardFront[i] + " " + GetCard.cardBack[i]);
        }

        progressText.text = "0/" + GetCard.cardFront.Length.ToString();
        startTime = Time.time;
    }
    public int displayNum;

    public void ShowCard ()
    {
        displayNum = QueOfCards ();
       
        if (displayNum == - 1)
        {
            bg.SetActive(false);
            testCard.SetActive(false);
            mainButton.SetActive(true);
            done.SetActive(true);
        } else
        {
            Time.timeScale = 0;
            bg.SetActive(true);
            displayText.text = "QUESTION! \n" + GetCard.cardFront[displayNum];
        }
        
    }

    public int QueOfCards()
    {
        for (int i = 0; i < spacedReps.Length; i++)
        {
            Debug.Log(GetCard.cardFront[i] + " " + GetCard.cardBack[i] + " " + spacedReps[i]);
        }

        float lowest = int.MaxValue;
        int lowestI = -1;
        for (int i = 0; i < spacedReps.Length; i++)
        {
            if (spacedReps[i] <= lowest &! CompletedCards.Contains(i))
            {
                lowest = spacedReps[i];
                lowestI = i;
            }
        }

        return lowestI;

    }

    public void RevealCard ()
    {
        displayText.text = "ANSWER! \n" + GetCard.cardBack[displayNum];
    }

    public void Rating ()
    {
        rating.SetActive(true);
    }

    //0 == lightwork
    //1 == good 
    //2 == medium 
    //3 == bad 

    public void RecordRating(int buttonRating)
    {

        //decrease all timers in spaced reps
        float elapsed = Time.time - startTime;

        Debug.Log("elapsed: " + elapsed);

        for (int i = 0; i < spacedReps.Length; i ++)
        {
            spacedReps[i] -= elapsed;
        } 

        if (buttonRating == 0)
        {
            CompletedCards.Add(displayNum);
            for (int i = 0; i < 5; i ++)
            {
                Instantiate(person, spawn);
            }

            progressText.text = CompletedCards.Count + "/" + GetCard.cardFront.Length.ToString();

            if (CompletedCards.Count == GetCard.cardFront.Length)
            {
                done.SetActive(true);
            }

        } else if (buttonRating == 1)
        {
            spacedReps[displayNum] = goodSpacing + 0.5f;
        }
        else if (buttonRating == 2)
        {
            spacedReps[displayNum] = medSpacing + 0.5f;
        }
        else
        {
            spacedReps[displayNum] = badSpacing + 0.5f;
        }

        rating.SetActive(false);
        mainButton.SetActive(true);
        testCard.SetActive(false);
        bg.SetActive(false);

        Time.timeScale = 1;
        startTime = Time.time;
    }

}
