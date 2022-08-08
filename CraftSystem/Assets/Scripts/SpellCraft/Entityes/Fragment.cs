using System;
using UnityEngine;

namespace SpellCraft
{
    [Serializable]
    [CreateAssetMenu(fileName = "Fragment", menuName = "SpellCraft/Fragment", order = 38)]
    public class Fragment : Entity
    {
        public FragmentType Type;
    }

    public enum FragmentType
    {
        Fire,
        Water
    }
}
