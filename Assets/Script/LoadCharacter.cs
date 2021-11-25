using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] CharacterPrefabs;
    public Transform SpawnPoint;
    

    private void Start()
    {
        int SelectedCharacter = PlayerPrefs.GetInt("ChooseCharacter");
        GameObject Prefab = CharacterPrefabs[SelectedCharacter];
        GameObject Clone = Instantiate(Prefab, SpawnPoint.position, Quaternion.identity);
       
    }
}
