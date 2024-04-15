

using Fusion;
using Managers;
using UnityEngine;
using static PlayerController;

namespace WolfCanTakeItem.Patch
{
    internal class PlayerControllerPatch
    {
        public static void Patch() 
        {
            On.PlayerController.CheckItemRayCast += PlayerController_CheckItemRayCast;
            On.PlayerController.UseItem += PlayerController_UseItem;
        }

        private static void PlayerController_UseItem(On.PlayerController.orig_UseItem orig, PlayerController self)
        {
            if (!GameManager.LightingManager.IsTransition && GameManager.State.Current == GameState.EGameState.Play && self.Item != null && !self.IsClimbing && (bool)self.CanMoveAnimation)
            {
                self.Item.Use();
            }
        }

        private static bool PlayerController_CheckItemRayCast(On.PlayerController.orig_CheckItemRayCast orig, PlayerController self, Item targetItem)
        {
            if (targetItem.Owner == PlayerRef.None)
            {
                GameManager.Instance.gameUI.UpdateInteraction("UI_LOOT_ITEM", Color.white, InputActionName.None);
                return true;
            }
            return false;
        }
    }
}
