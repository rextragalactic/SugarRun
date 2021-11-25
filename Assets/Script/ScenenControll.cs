using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenenControll : MonoBehaviour
{
    enum eLevels
    {
        Menu,
        ChooseCharacter,
        SmallMenu,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6,
        Level7,
        Level8,
        Level9,
        Level10,
        Level11,
        Level12,
        Level13,
        Level14,
        Level15


    }

    [SerializeField]
    eLevels CurrentLevel = eLevels.Level1;

    public void GoToGameScene()
    {

        switch (CurrentLevel)
        {
            case eLevels.Menu:
                SceneManager.LoadScene("ChooseCharacter");
                break;
            case eLevels.ChooseCharacter:
                SceneManager.LoadScene("Level1");
                break;
            case eLevels.Level1:
                SceneManager.LoadScene("Level2");
                break;
            case eLevels.Level2:
                SceneManager.LoadScene("Level3");
                break;
            case eLevels.Level3:
                SceneManager.LoadScene("Level4");
                break;
            case eLevels.Level4:
                SceneManager.LoadScene("Level5");
                break;
            case eLevels.Level5:
                SceneManager.LoadScene("Level6");
                break;
            case eLevels.Level6:
                SceneManager.LoadScene("Level7");
                break;
            case eLevels.Level7:
                SceneManager.LoadScene("Level8");
                break;
            case eLevels.Level8:
                SceneManager.LoadScene("Level9");
                break;
            case eLevels.Level9:
                SceneManager.LoadScene("Level10");
                break;
            case eLevels.Level10:
                SceneManager.LoadScene("Level11");
                break;
            case eLevels.Level11:
                SceneManager.LoadScene("Level12");
                break;
            case eLevels.Level12:
                SceneManager.LoadScene("Level13");
                break;
            case eLevels.Level13:
                SceneManager.LoadScene("Level14");
                break;
            case eLevels.Level14:
                SceneManager.LoadScene("Level15");
                break;
            case eLevels.Level15:
                SceneManager.LoadScene("Menu");
                break;

            default:
                SceneManager.LoadScene("Level1");
                break;
        }
    }

    public void Quit()
    {
        Application.Quit();

    }

    public void Reset()
    {
        switch (CurrentLevel)
        {
            case eLevels.Level1:
                SceneManager.LoadScene("Level1");
                break;
            case eLevels.Level2:
                SceneManager.LoadScene("Level2");
                break;
            case eLevels.Level3:
                SceneManager.LoadScene("Level3");
                break;
            case eLevels.Level4:
                SceneManager.LoadScene("Level4");
                break;
            case eLevels.Level5:
                SceneManager.LoadScene("Level5");
                break;
            case eLevels.Level6:
                SceneManager.LoadScene("Level6");
                break;
            case eLevels.Level7:
                SceneManager.LoadScene("Level7");
                break;
            case eLevels.Level8:
                SceneManager.LoadScene("Level8");
                break;
            case eLevels.Level9:
                SceneManager.LoadScene("Level9");
                break;
            case eLevels.Level10:
                SceneManager.LoadScene("Level10");
                break;
            case eLevels.Level11:
                SceneManager.LoadScene("Level11");
                break;
            case eLevels.Level12:
                SceneManager.LoadScene("Level12");
                break;
            case eLevels.Level13:
                SceneManager.LoadScene("Level13");
                break;
            case eLevels.Level14:
                SceneManager.LoadScene("Level14");
                break;
            case eLevels.Level15:
                SceneManager.LoadScene("Level15");
                break;


            default:
                SceneManager.LoadScene("Level1");
                break;
        }

       
    }

    
}
