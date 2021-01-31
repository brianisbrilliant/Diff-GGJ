using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStealer : MonoBehaviour
{
    // make a list of all items tagged as 'misplaceable' and turn one off.
    // randomly select 3-5 of those items, add the one that IS missing, and display those items along the bottom of the screen
    // give the player 30 seconds to find the missing item!

    public GameObject[] items;

    public GameObject missingItem;

    public GameObject screen;

    [Range(1,5)]
    public float waitTime = 2f;

    void Start() {
        if(screen != null) screen.SetActive(false);

        items = GameObject.FindGameObjectsWithTag("Misplaceable");

        StartCoroutine(HideItem());
    }

    IEnumerator HideItem() {
        Debug.Log("You have " + waitTime +" seconds to memorize the room!");
        yield return new WaitForSeconds(waitTime);
        if(screen != null) screen.SetActive(true);

        missingItem = items[Random.Range(0,items.Length)];
        missingItem.SetActive(false);
        Debug.Log("Let's hide the " + missingItem.name);

        yield return new WaitForSeconds(1);
        if(screen != null) screen.SetActive(false);


    }
}