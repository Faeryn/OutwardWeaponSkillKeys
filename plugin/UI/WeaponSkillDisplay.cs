using UnityEngine;
using UnityEngine.UI;
using WeaponSkillKeys.Extensions;

namespace WeaponSkillKeys.UI {
    public class WeaponSkillDisplay : MonoBehaviour {
        private ItemDisplay itemDisplay;
        private Image imgItemIcon;
        private Text lblQuantity;

        protected void Awake() {
            itemDisplay = GetComponent<ItemDisplay>();
            imgItemIcon = transform.Find("Icon").GetComponent<Image>();
            lblQuantity = transform.Find("lblQuantity").GetComponent<Text>();
            itemDisplay.SetLblQuantity(null);
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
    }
}