using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComputacionGrafica.Airport.Networking
{
    public class PlayerInstallerNetworking : MonoBehaviour
    {
        /*
        [SerializeField] private GameObject _prefabPlayer;
        //[SerializeField] private MainHud _mainHud;
        //[SerializeField] private int _inputId;
        //[SerializeField] private Toggle _toggleMove;
        [SerializeField] private CinemachineFreeLook _cinemachineFreeLook;
        [SerializeField] private Transform _startPositionPlayer;

        private AbstractPlayerMediator _player;

        [Header("UI Control")]
        [SerializeField] private GameObject _controlEnabled;
        [SerializeField] private GameObject _controlDesabled;
        [SerializeField] private Sprite _mouse;
        [SerializeField] private Sprite _keyboard;

        [SerializeField] private bool _useNormalMove = false;

        private void Awake()
        {
            if (PlayerNetworkingController.LocalPlayerInstance == null)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);

                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                _player = PhotonNetwork.Instantiate(_prefabPlayer.name, _startPositionPlayer.position, _startPositionPlayer.rotation, 0).GetComponent<AbstractPlayerMediator>();
            }
            else
            {
                Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);

                _player = PlayerNetworkingController.LocalPlayerInstance.GetComponent<AbstractPlayerMediator>();
            }

            _player.Configure(_useNormalMove);

            _player.CinemachineFreeLook = _cinemachineFreeLook;
            _cinemachineFreeLook.Follow = _player.FollowCameraTransform;
            _cinemachineFreeLook.LookAt = _player.LookAtCameraTransform;

            SetMove(_useNormalMove);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                switch (_useNormalMove)
                {
                    case true:
                        _useNormalMove = false;
                        _controlEnabled.GetComponent<Image>().sprite = _mouse;
                        _controlEnabled.GetComponent<Image>().SetNativeSize();
                        _controlDesabled.GetComponent<Image>().sprite = _keyboard;
                        _controlDesabled.GetComponent<Image>().SetNativeSize();
                        SetMove(_useNormalMove);
                        break;
                    case false:
                        _useNormalMove = true;
                        _controlEnabled.GetComponent<Image>().sprite = _keyboard;
                        _controlEnabled.GetComponent<Image>().SetNativeSize();
                        _controlDesabled.GetComponent<Image>().sprite = _mouse;
                        _controlDesabled.GetComponent<Image>().SetNativeSize();
                        SetMove(_useNormalMove);
                        break;
                }
            }
        }

        public void SetMove(bool useNormalMove)
        {
            _player.SetMove(useNormalMove);
        }
        */
    }
}
