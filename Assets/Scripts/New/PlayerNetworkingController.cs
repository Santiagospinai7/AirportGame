using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace ComputacionGrafica.Airport
{
    public class PlayerNetworkingController : MonoBehaviourPunCallbacks
    {
        /*
        [SerializeField] private AbstractPlayerMediator _player;
        [SerializeField] private PhotonView _photonView;

        public static GameObject LocalPlayerInstance { get; private set; }

        public PhotonView PhotonView => _photonView;

        private void Start()
        {
            if (_photonView.IsMine)
            {
                LocalPlayerInstance = gameObject;
            }

            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(gameObject);
        }

        public void UpdateData()
        {
            if (_photonView.IsMine)
            {
                Hashtable hash = new Hashtable();
                string property = "test";
                hash.Add("keyproperty", property);
                PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
            }
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            if (!_photonView.IsMine && targetPlayer == _photonView.Owner && changedProps["keyproperty"] != null)
            {
                // Hacer algo
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                // We own this player: send the others our data
                stream.SendNext(_player.IsSprinting);
                stream.SendNext(_player.IsJumping);
            }
            else
            {
                // Network player, receive data
                _player.IsSprinting = (bool)stream.ReceiveNext();
                _player.IsJumping = (bool)stream.ReceiveNext();
            }
        }
        */
    }
}
