using UnityEditor;
using UnityEngine;
using UnityGamingServicesUsesCases.Relationships;

[CustomEditor(typeof(PlayerProfilesData))]
public class PlayerProfilesDataDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Clear",  GUILayout.Height(35)))
        {
            var playerProfilesData = (PlayerProfilesData)target;
            playerProfilesData.Clear();
        }
    }
}