using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMechanics
{
    public class AvatarMechanic : MonoBehaviour
    {
        public RefereeMechanic _scrRefereeMechanic;

        #region HandleCoreMechanic

        public virtual void HandleCoreMechanic(CoreMechanicType type, bool value)
        {
            switch (type)
            {
                default:

                    break;
            }
        }

        public virtual void HandleCoreMechanic(CoreMechanicType type, Vector2 value)
        {
            switch (type)
            {
                default:

                    break;
            }
        }

        public virtual void HandleCoreMechanic(CoreMechanicType type, float value)
        {
            switch (type)
            {
                default:

                    break;
            }
        }

        #endregion

        #region Setters

        public RefereeMechanic SetRefereeMechanic
        {
            set
            {
                _scrRefereeMechanic = value;
            }
        }

        #endregion
    }
}