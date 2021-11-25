using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{

    private GameObject[] characterList;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];  // definding the size of the Array

        // Fill the array with Characters
        for(int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        // Hide them 
        foreach (GameObject go in characterList)
            go.SetActive(false);

        if (characterList[0])
        {
            characterList[index].SetActive(true);
        }
        
    }

    public void Previous() // When User clics on Left button to go back to the previos character
    {
        // Hide the current Character
        characterList[index].SetActive(false);


        index --;
        if (index < 0)
            index = characterList.Length - 1;

        // Show new Character
        characterList[index].SetActive(true);

    }

    public void Next() // When User clics on Right button to go to the next character
    {
        // Hide the current Character
        characterList[index].SetActive(false);


        index++;
        if (index == characterList.Length)
            index = 0;

        // Show new Character
        characterList[index].SetActive(true);

    }

    public void PlayButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Level1");
    }
}
