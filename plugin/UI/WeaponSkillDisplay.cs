using UnityEngine;
using UnityEngine.UI;

namespace WeaponSkillKeys.UI {
    public class WeaponSkillDisplay : MonoBehaviour {
        private ItemDisplay itemDisplay;
        private Image imgItemIcon;
        private Text lblQuantity;

        protected void Awake() {
            itemDisplay = GetComponent<ItemDisplay>();
            imgItemIcon = transform.Find("Icon").GetComponent<Image>();
            lblQuantity = transform.Find("lblQuantity").GetComponent<Text>();
            
            Image imgNewIcon = transform.Find("imgNew").GetComponent<Image>();
            Destroy(imgNewIcon);
            
            itemDisplay.m_lblQuantity = null;
        }

        protected void Update() {
            Item item = itemDisplay.RefItem;
            bool hasItem = item;
            if (Time.frameCount % 2 == 0 && hasItem && imgItemIcon.overrideSprite != itemDisplay.RefItem.QuickSlotIcon) {
                imgItemIcon.overrideSprite = itemDisplay.RefItem.QuickSlotIcon;
            }

            if (hasItem && item is Skill) {
                int count = ((Skill)item).GetLowestOwnedReqItemCount();
                lblQuantity.text = count > -1 ? count.ToString() : "";
            }
        }

        public void Clear() {
            SkillCooldownDisplay cooldownDisplay = itemDisplay.m_cooldownDisplay;
            if (cooldownDisplay) {
                cooldownDisplay.SetReferencedItem(null);
            }
            itemDisplay.Clear();
            lblQuantity.text = "";
            UpdateVisibility();
        }

        public void UpdateVisibility() {
            if (!WeaponSkillKeys.HideEmpty.Value || itemDisplay.RefItem) {
                itemDisplay.Show();
            } else {
                itemDisplay.Hide();
            }
        }

        public void SetSkill(Skill skill) {
            lblQuantity.text = "";
            itemDisplay.SetReferencedItem(skill);
            UpdateVisibility();
        }
    }
}