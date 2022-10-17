using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGamingServicesUsesCases.Relationships
{
    public class FriendsView : MonoBehaviour, IFriendsListView
    {
       // public Action<string> OnFriendRemove = null;
       // public Action<string> OnFriendBlock = null;

        [SerializeField]private RectTransform m_ParentTransform = null;
        [SerializeField]private FriendsEntryView m_FriendEntryViewPrefab = null;

        List<FriendsEntryView> m_Friends = new List<FriendsEntryView>();

        private List<FriendsEntryData> m_FriendsEntryDatas = new List<FriendsEntryData>();

        public void Refresh(List<FriendsEntryData> friendsEntryDatas)
        {
            foreach (var entry in m_Friends)
            {
                Destroy(entry.gameObject);
            }
            m_Friends.Clear();

            foreach (var friendsEntryData in friendsEntryDatas)
            {
                var entry = Instantiate(m_FriendEntryViewPrefab, m_ParentTransform);
                entry.Init(friendsEntryData.Name,friendsEntryData.Availability.ToString(), friendsEntryData.Activity);
                entry.button1.onClick.AddListener(() =>
                {
                    onRemoveFriend?.Invoke(friendsEntryData.Id);
                });
                entry.button2.onClick.AddListener(() =>
                {
                    onBlockFriend?.Invoke(friendsEntryData.Id);
                });
                m_Friends.Add(entry);
            }
        }

        public Action<string> onRemoveFriend { get; set; }
        public Action<string> onBlockFriend { get; set; }
        public void BindList(List<FriendsEntryData> listToBind)
        {
            m_FriendsEntryDatas = listToBind;
        }

        public void Show()
        {
            Refresh();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Refresh()
        {
            Refresh(m_FriendsEntryDatas);
        }
    }
}
