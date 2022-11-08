using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public static GameSetup GS;

    public Transform[] spawnPoints;

    private GameObject _playerObj;
    private GameObject _cameraObj;
    public Vector3 offset;

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            GameObject o = PhotonNetwork.Instantiate(_player.name, spawnPoints[0].position, spawnPoints[1].rotation, 0);

            _playerObj = o;
            _cameraObj = Camera.main.gameObject;
            _cameraObj.transform.position = _playerObj.transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (_playerObj != null && _cameraObj != null)
        {
            _cameraObj.transform.position = _playerObj.transform.position - offset;
        }
        //Debug.Log("Camera position: " + _cameraObj.transform.position);
    }

    private void OnEnable()
    {
        if (GameSetup.GS == null)
        {
            GameSetup.GS = this;
        }
    }
}
