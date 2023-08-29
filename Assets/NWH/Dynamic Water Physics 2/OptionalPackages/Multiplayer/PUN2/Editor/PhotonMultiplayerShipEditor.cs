#if UNITY_EDITOR
using NWH.DWP2.Multiplayer;
using NWH.NUI;
using UnityEditor;

namespace NWH.DWP2.Multiplayer.PUN2
{
    [CustomEditor(typeof(PhotonMultiplayerShip))]
    [CanEditMultipleObjects]
    public class PhotonMultiplayerShipEditor : NUIEditor
    {
        public override bool OnInspectorNUI()
        {
            if (!base.OnInspectorNUI())
            {
                return false;
            }

            PhotonMultiplayerShip pmv = target as PhotonMultiplayerShip;
            
            if (pmv == null)
            {
                drawer.EndEditor();
                return false;
            }

            drawer.Field("sendRate");
            drawer.Field("simulateWaterObjectsOnClient");
            drawer.Field("serializationRate");
            drawer.Info(
                "'Observe option' field of Photon View is not settable through scripting so make sure it is not set to 'Off'.",
                MessageType.Warning);

            drawer.EndEditor(this);
            return true;
        }

        public override bool UseDefaultMargins()
        {
            return false;
        }
    }
}

#endif
