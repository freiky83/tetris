using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
        /// <summary>
        /// L'attaque de base de l'arme
        /// </summary>
        /// <param name="p_originTransform"> Position d'origine de l'attaque </param>
        /// <param name="p_targetTransform"> Position de la cible </param>
        public void Attack(Transform p_originTransform, Transform p_targetTransform);

        /// <summary>
        ///  L'attaque spéciale de l'arme
        /// </summary>
        /// <param name="p_originTransform"> Position d'origine de l'attaque </param>
        /// <param name="p_targetTransform"> Position de la cible </param>
        public void AttackSpecial(Transform p_originTransform, Transform p_targetTransform);
}
