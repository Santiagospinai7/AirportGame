using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView _PV;
    public GameObject myAvatar;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("photon player script");
        _PV = GetComponent<PhotonView>();
        //int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
        int spawnPicker = 0;

        if (_PV.IsMine)
        {
            Debug.Log("instantiate avatar");
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("Models", "PlayerAvatar"), GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
