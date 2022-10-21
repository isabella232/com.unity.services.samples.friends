using TMPro;
using Unity.Services.Friends.Models;
using UnityEngine;
using UnityEngine.UI;

namespace UnityGamingServicesUsesCases.Relationships.UGUI
{
    public class FriendEntryViewUGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_NameText = null;
        [SerializeField] private TextMeshProUGUI m_PresenceText = null;
        [SerializeField] private TextMeshProUGUI m_ActivityText = null;
        [SerializeField] private Image m_PresenceColorImage = null;

        public Button removeFriendButton = null;
        public Button blockFriendButton = null;

        public void Init(string playerName, PresenceAvailabilityOptions presence, string activity)
        {
            m_NameText.text = playerName;
            m_PresenceText.text = presence.ToString();
            var presenceColor = ColorUtils.GetPresenceColor(presence);
            m_PresenceText.color = presenceColor;
            m_PresenceColorImage.color = presenceColor;
            m_ActivityText.text = activity;
        }
    }
}