using System;
using NWH.DWP2.ShipController;
using NWH.DWP2.WaterObjects;
using Photon.Pun;
using UnityEngine;

namespace NWH.DWP2.Multiplayer.PUN2
{
    /// <summary>
    ///     Adds multi-player functionality to a vehicle through Photon Unity Networking 2.
    /// </summary>
    [RequireComponent(typeof(PhotonRigidbodyView))]
    [RequireComponent(typeof(PhotonTransformView))]
    [RequireComponent(typeof(PhotonView))]
    [RequireComponent(typeof(AdvancedShipController))]
    public class PhotonMultiplayerShip : MonoBehaviour, IPunObservable
    {
        public  bool                simulateWaterObjectsOnClient = true;
        public  int                 sendRate                     = 12;
        public  int                 serializationRate            = 12;
        private PhotonRigidbodyView _photonRigidbodyView;
        private PhotonTransformView _photonTransformView;
        private PhotonView          _photonView;

        private AdvancedShipController _shipController;


        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                // Send
                stream.SendNext(_shipController.input.Steering);
                stream.SendNext(_shipController.input.Throttle);
                stream.SendNext(_shipController.input.Throttle2);
                stream.SendNext(_shipController.input.Throttle3);
                stream.SendNext(_shipController.input.Throttle4);
                stream.SendNext(_shipController.input.BowThruster);
                stream.SendNext(_shipController.input.SternThruster);
                stream.SendNext(_shipController.input.EngineStartStop);
            }
            else
            {
                // Receive
                _shipController.input.autoSetInput = false;
                _shipController.input.Steering     = (float) stream.ReceiveNext();
                _shipController.input.Throttle     = (float) stream.ReceiveNext();
                _shipController.input.Throttle2    = (float) stream.ReceiveNext();
                _shipController.input.Throttle3    = (float) stream.ReceiveNext();
                _shipController.input.Throttle4    = (float) stream.ReceiveNext();
                _shipController.input.BowThruster  = (float) stream.ReceiveNext();
                _shipController.input.SternThruster= (float) stream.ReceiveNext();
                _shipController.input.EngineStartStop= (bool) stream.ReceiveNext();
            }
        }

        private void Initialize()
        {
            _shipController   = GetComponent<AdvancedShipController>();
            _photonView          = GetComponent<PhotonView>();
            _photonRigidbodyView = GetComponent<PhotonRigidbodyView>();
            _photonTransformView = GetComponent<PhotonTransformView>();

            PhotonNetwork.SendRate          = sendRate;
            PhotonNetwork.SerializationRate = serializationRate;

            _shipController.MultiplayerIsRemote = !_photonView.IsMine;

            // Disable water objects if not local as the position is synced
            if (_shipController.MultiplayerIsRemote && !simulateWaterObjectsOnClient)
            {
                foreach (WaterObject waterObject in gameObject.GetComponentsInChildren<WaterObject>())
                {
                    waterObject.enabled = false;
                }
            }

            _photonView.ObservedComponents.Clear();
            _photonView.ObservedComponents.Add(_photonRigidbodyView);
            _photonView.ObservedComponents.Add(_photonTransformView);
            _photonView.ObservedComponents.Add(this);
        }


        private void Awake()
        {
            _shipController = GetComponent<AdvancedShipController>();
            _shipController.onShipInitialized.AddListener(Initialize);
        }
    }
}