using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStateManager : MonoBehaviour
{
    float timer;
    int chairsBurned;
    bool choreCompleted;

    int cookingLevel;
    float cookingTime;
    float cookingTimer; 

    public GameObject timerUI;
    public GameObject winTextUI;
    public GameObject cookingUI;
    public GameObject cookingTextUI;
    // Start is called before the first frame update
    void Start()
    {
        timer = 300;
        choreCompleted = false;
        chairsBurned = 0;
        cookingTime = 37;
        cookingLevel = 0;
        cookingTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cookingTimer > 0)
        {
            cookingTimer -= Time.deltaTime;
            cookingTextUI.GetComponent<UnityEngine.UI.Text>().text = "Cooking: " + cookingTimer;
        }
        else if (cookingLevel > 2)
        {
            choreCompleted = true;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerUI.GetComponent<UnityEngine.UI.Text>().text = "" + timer;
        }
        if(timer <= 0){
            if(choreCompleted){
                gameOver("Dad");
            }
            else gameOver("Babies");
        }

    }
   public void chairBurned()
    {
        chairsBurned += 1;
        if (chairsBurned > 2)
        {
            gameOver("Babies");
        }
    }
    void gameOver(string winner)
    {
        winTextUI.GetComponent<UnityEngine.UI.Text>().text = "Game Over." + winner + " Won!";
    }
    public void Cook()
    {
        if (cookingTimer <= 0)
        {
            cookingTimer = cookingTime;
            cookingLevel += 1;
        }
    }
}
