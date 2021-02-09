using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemStealer : MonoBehaviour
{
    // make a list of all items tagged as 'misplaceable' and turn one off.
    // randomly select 3-5 of those items, add the one that IS missing, and display those items along the bottom of the screen
    // give the player 30 seconds to find the missing item!

    [Header("Misplaceable Object Management")]

    public GameObject[] items;

    public GameObject missingItem;


    [Header("UI")]
    public TextMeshProUGUI countdownText;
    public GameObject screen;

    [Range(1,10)]
    public float waitTime = 2f;

    float timer;

    void Start() {
        if(screen != null) screen.SetActive(false);

        items = GameObject.FindGameObjectsWithTag("Misplaceable");

        timer = waitTime;

        StartCoroutine(HideItem());
    }

    void Update() {
        timer -= Time.deltaTime;
        if(timer > 0) countdownText.text = "You have " + timer.ToString("0") + " seconds to memorize the room!";
    }

    IEnumerator HideItem() {
        Debug.Log("You have " + waitTime +" seconds to memorize the room!");
        yield return new WaitForSeconds(waitTime);
        if(screen != null) screen.SetActive(true);
        countdownText.text = "[misplacing item...]";

        missingItem = items[Random.Range(0,items.Length)];
        missingItem.SetActive(false);
        Debug.Log("Let's hide the " + missingItem.name);

        yield return new WaitForSeconds(2);
        if(screen != null) screen.SetActive(false);
        countdownText.text = "What is missing?";


    }
}