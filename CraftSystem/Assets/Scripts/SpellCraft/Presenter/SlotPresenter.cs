using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpellCraft
{
    public class SlotPresenter : MonoBehaviour
    {
        [SerializeField] private Slot<Entity> _craftSlot;
        [SerializeField] private Image _slotImage;

        private void OnEnable()
        {
            _craftSlot.SpellPlaced += OnSpellPlaced;
            _craftSlot.SpellRemoving += OnSpellRemoving;
        }

        private void OnDisable() 
        {
            _craftSlot.SpellPlaced -= OnSpellPlaced;
            _craftSlot.SpellRemoving -= OnSpellRemoving;
        }

        protected virtual void OnSpellPlaced(Entity spell)
        {
            _slotImage.sprite = spell.Sprite;
        }

        protected virtual void OnSpellRemoving(Entity spell)
        {
            _slotImage.sprite = null;
        }
    }
}