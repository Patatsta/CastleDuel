using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasManager : MonoBehaviour
{
    private static CanvasManager _instance;
    public static CanvasManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("CanvasManager == NULL");
            return _instance;

        }
    }

    [SerializeField] private GameObject _startCanvas;
    [SerializeField] private GameObject _gameCanvas;
    [SerializeField] private GameObject _endCanvas;
    [SerializeField] private TMP_Text _winText;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _startCanvas.SetActive(true);
        _gameCanvas.SetActive(false);
        _endCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartedGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _startCanvas.SetActive(false);
        _gameCanvas.SetActive(true);
    }

    public void EndGame(string text)
    {
        _winText.text = text;
        _gameCanvas.SetActive(false);
        _endCanvas.SetActive(true);
    }



}

