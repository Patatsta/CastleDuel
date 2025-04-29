using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("GameManager == Null");

            return _instance;

        }
    }


    public static Action<int> OnHitFloor;

    private List<CastleStone> _p1Stones = new List<CastleStone>();
    private List<CastleStone> _p2Stones = new List<CastleStone>();

    [SerializeField] private int _P1HP;
    [SerializeField] private int _P2HP;

    [SerializeField] private Slider _p1Slider;
    [SerializeField] private Slider _p2Slider;

    private int _currentBallVariant;
    private int _ballIndex = 0;
    public bool _gameEnd = false;

    [SerializeField] private int _loseThreshold;
    private void Awake()
    {
        _instance = this;
    }

    
    public int CurrentBallVariant()
    {

        if(_ballIndex >= 2)
        {
            _currentBallVariant = UnityEngine.Random.Range(0, 3);
            _ballIndex = 0;
        }
        _ballIndex++;
        return _currentBallVariant;
    }

    IEnumerator Start()
    {
        yield return null;


        _currentBallVariant = UnityEngine.Random.Range(0, 3);
    
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

        _p1Slider.minValue = _loseThreshold;
        _p2Slider.minValue = _loseThreshold;

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

        if(_P1HP <= _loseThreshold)
        {
            _gameEnd = true;
            CanvasManager.Instance.EndGame("Player 2 Wins!");
            StartCoroutine(PlayAgain());
            CameraManager.Instance.EndGameCamera();
        }
        if(_P2HP <= _loseThreshold)
        {
            _gameEnd = true;
            CanvasManager.Instance.EndGame("Player 1 Wins!");
            StartCoroutine(PlayAgain());
            CameraManager.Instance.EndGameCamera();
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
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
