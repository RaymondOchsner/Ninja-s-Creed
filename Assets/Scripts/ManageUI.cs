using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManageUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

}
