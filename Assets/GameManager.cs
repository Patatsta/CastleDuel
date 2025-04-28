using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Action<int> OnHitFloor;

    private List<CastleStone> _p1Stones = new List<CastleStone>();
    private List<CastleStone> _p2Stones = new List<CastleStone>();

    [SerializeField] private int _P1HP;
    [SerializeField] private int _P2HP;

    [SerializeField] private Slider _p1Slider;
    [SerializeField] private Slider _p2Slider;

    void Start()
    {
        CastleStone[] allStones = GameObject.FindObjectsOfType<CastleStone>();
        Debug.Log("Found stones: " + allStones.Length);

        foreach (CastleStone stone in allStones)
        {
            if (stone.ID == 1)
            {
        
                _p1Stones.Add(stone);
            }
            else if (stone.ID == 2)
            {
           
                _p2Stones.Add(stone);
            }
        }
        _P1HP = _p1Stones.Count;
        _P2HP = _p2Stones.Count;

        _p1Slider.maxValue = _P1HP;
        _p2Slider.maxValue = _P2HP;
        _p1Slider.value = _P1HP;
        _p2Slider.value = _P2HP;
      
       
        OnHitFloor = AddPoints;
    }

    private void AddPoints(int id)
    {
        if(id == 1)
        {
       
            _P1HP--;
            _p1Slider.value = _P1HP;
        }
        if (id == 2)
        {
            
            _P2HP--;
            _p2Slider.value = _P2HP;
        }

        if(_P1HP <= 300)
        {
            CanvasManager.Instance.EndGame("Player 1 Wins!");
            StartCoroutine(PlayAgain());
            CameraManager.Instance.EndGameCamera();
        }
        if(_P2HP <= 300)
        {
            CanvasManager.Instance.EndGame("Player 2 Wins!");
            StartCoroutine(PlayAgain());
            CameraManager.Instance.EndGameCamera();
        }
    }


    public void QuitButton()
    {
        Application.Quit();
    }

    IEnumerator PlayAgain()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
