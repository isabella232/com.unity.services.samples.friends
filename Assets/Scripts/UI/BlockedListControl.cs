using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace UnityGamingServicesUsesCases.Relationships.UI
{
    public class BlockedListControl
    {
        const string k_BlockedListViewName = "blocked-list";

        public Action<string> onUnBlock;

        ListView m_BlockedListView;

        /// <summary>
        /// Finds and binds the UI Elements with the controller
        /// </summary>
        /// <param name="viewParent">One of the parents of the friends-list (In RelationShipBarView.uxml)</param>
        /// <param name="blockFriendTemplate">The Friends Template (FriendListEntry.uxml) </param>
        /// <param name="boundBlockedProfiles">The List of users we bind the listview to.</param>
        public BlockedListControl(VisualElement viewParent, VisualTreeAsset blockFriendTemplate)
        {
            m_BlockedListView = viewParent.Q<ListView>(k_BlockedListViewName);

            m_BlockedListView.makeItem = () =>
            {
                var newListEntry = blockFriendTemplate.Instantiate();
                var newListEntryLogic = new BlockedEntryControl(newListEntry.contentContainer);
                newListEntry.userData = newListEntryLogic;
                return newListEntry;
            };
        }

        public void BindList(List<PlayerProfile> blockedListToBind)
        {
            m_BlockedListView.bindItem = (item, index) =>
            {
                var blockedEntryControl = item.userData as BlockedEntryControl;
                var userProfile = blockedListToBind[index];
                blockedEntryControl.playerEntryControl.SetName(userProfile.Name);
                blockedEntryControl.onUnblock = () =>
                {
                    onUnBlock?.Invoke(userProfile.Id);
                };
            };

            m_BlockedListView.itemsSource = blockedListToBind;
            Refresh();
        }

        public void Show(bool show)
        {
            m_BlockedListView.style.display = show ? DisplayStyle.Flex : DisplayStyle.None;
        }

        /// <summary>
        /// Force a refresh now!
        /// </summary>
        public void Refresh()
        {
            m_BlockedListView.RefreshItems();
        }
    }
}
