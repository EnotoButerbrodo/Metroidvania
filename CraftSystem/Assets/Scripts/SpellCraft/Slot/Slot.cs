using SpellCraft;
using System;
using UnityEngine;

namespace SpellCraft
{
    public class Slot<TEntity> : MonoBehaviour
        where TEntity : Entity
    {

        [SerializeField] private TEntity _item;

        public event Action<TEntity> SpellPlaced;
        public event Action<TEntity> SpellRemoving;
        public void Place(TEntity spell)
        {
            _item = spell;
            SpellPlaced?.Invoke(_item);
        }
        public void Remove()
        {
            SpellRemoving?.Invoke(_item);
            _item = null;
        }

    }

}