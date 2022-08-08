using SpellCraft;
using System;
using UnityEngine;

namespace SpellCraft
{
    public abstract class Slot<TEntity> : MonoBehaviour
        where TEntity : class
    {

        [SerializeField] private TEntity _item;

        public Action<TEntity> SpellPlaced;
        public Action<TEntity> SpellRemoving;
        public virtual void Place(TEntity spell)
        {
            _item = spell;
            SpellPlaced?.Invoke(_item);
        }
        public virtual void Remove()
        {
            SpellRemoving?.Invoke(_item);
            _item = null;
        }


    }
}