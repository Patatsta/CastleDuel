using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
    private static CameraManager _instance;
    public static CameraManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("CameraManager == Null");

            return _instance;
        }
    }

    [SerializeField] private Cannon _player1;
    [SerializeField] private Cannon _player2;

    [SerializeField] private CinemachineVirtualCamera _p1Cam;
    [SerializeField] private CinemachineVirtualCamera _p2Cam;
    [SerializeField] private CinemachineVirtualCamera _neutralCam;

    private bool _isPlayer1Turn = false;

    private Coroutine _changeCoro;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _player1.Activate(false);
        _player2.Activate(false);

        _p1Cam.Priority = 0;
        _p2Cam.Priority = 0;
        _neutralCam.Priority = 10;
    }

    public void DeactivatePlayers()
    {
    
       _player1.Activate(false);
    
       _player2.Activate(false);
        
    }
    IEnumerator SwitchPlayer(float delay)
    {
        
        yield return new WaitForSeconds(delay);

        _p1Cam.Priority = 0;
        _p2Cam.Priority = 0;

        yield return new WaitForSeconds(3);

        if (_isPlayer1Turn)
        {
            _player1.Activate(false);
            _player2.Activate(true);
            _p1Cam.Priority = 0;
            _p2Cam.Priority = 20;

        }
        else
        {
            _player1.Activate(true);
            _player2.Activate(false);
            _p1Cam.Priority = 20;
            _p2Cam.Priority = 0;
        }

        _isPlayer1Turn = !_isPlayer1Turn;
    }
    public void ChangePlayer()
    {
       _changeCoro =  StartCoroutine(SwitchPlayer(1));
    }

    public void EndGameCamera()
    {
        _player1.Activate(false);
        _player2.Activate(false);

        _p1Cam.Priority = 0;
        _p2Cam.Priority = 0;
        _neutralCam.Priority = 10;
    }

    public void StartGameManager()
    {
        if (_isPlayer1Turn)
        {
            _player1.Activate(false);
            _player2.Activate(true);
            _p1Cam.Priority = 0;
            _p2Cam.Priority = 20;

        }
        else
        {
            _player1.Activate(true);
            _player2.Activate(false);
            _p1Cam.Priority = 20;
            _p2Cam.Priority = 0;
        }

        _isPlayer1Turn = !_isPlayer1Turn;
    }    
}
