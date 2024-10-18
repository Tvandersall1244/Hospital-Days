using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalController : MonoBehaviour
{
    [SerializeField]
    public GameObject JournalUI;
    public GameObject gameCamera;
    public GameObject DayOneScene;
    public GameObject DayTwoScene;
    public GameObject DayThreeScene;
    public GameObject DayFourScene;
    public GameObject DayFiveScene;
    public GameObject DaySixScene;
    public GameObject DaySevenScene;

    public void changeToDayOne() {
        DayOneScene.SetActive(true);
        DayTwoScene.SetActive(false);
        DayThreeScene.SetActive(false);
        DayFourScene.SetActive(false);
        DayFiveScene.SetActive(false);
        DaySixScene.SetActive(false);
        DaySevenScene.SetActive(false);
    }

    public void changeToDayTwo() {
        DayOneScene.SetActive(false);
        DayTwoScene.SetActive(true);
        DayThreeScene.SetActive(false);
        DayFourScene.SetActive(false);
        DayFiveScene.SetActive(false);
        DaySixScene.SetActive(false);
        DaySevenScene.SetActive(false);
    }

        public void changeToDayThree() {
        DayOneScene.SetActive(false);
        DayTwoScene.SetActive(false);
        DayThreeScene.SetActive(true);
        DayFourScene.SetActive(false);
        DayFiveScene.SetActive(false);
        DaySixScene.SetActive(false);
        DaySevenScene.SetActive(false);
    }

        public void changeToDayFour() {
        DayOneScene.SetActive(false);
        DayTwoScene.SetActive(false);
        DayThreeScene.SetActive(false);
        DayFourScene.SetActive(true);
        DayFiveScene.SetActive(false);
        DaySixScene.SetActive(false);
        DaySevenScene.SetActive(false);
    }

        public void changeToDayFive() {
        DayOneScene.SetActive(false);
        DayTwoScene.SetActive(false);
        DayThreeScene.SetActive(false);
        DayFourScene.SetActive(false);
        DayFiveScene.SetActive(true);
        DaySixScene.SetActive(false);
        DaySevenScene.SetActive(false);
    }

        public void changeToDaySix() {
        DayOneScene.SetActive(false);
        DayTwoScene.SetActive(false);
        DayThreeScene.SetActive(false);
        DayFourScene.SetActive(false);
        DayFiveScene.SetActive(false);
        DaySixScene.SetActive(true);
        DaySevenScene.SetActive(false);
    }

        public void changeToDaySeven() {
        DayOneScene.SetActive(false);
        DayTwoScene.SetActive(false);
        DayThreeScene.SetActive(false);
        DayFourScene.SetActive(false);
        DayFiveScene.SetActive(false);
        DaySixScene.SetActive(false);
        DaySevenScene.SetActive(true);
    }

    public void exitJournal() {
        JournalUI.SetActive(false);
        gameCamera.GetComponent<CameraMovement>().enabled = true;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
