using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameMechanics
{
    public enum GameState
    {
        IN_GAME,
        PAUSE_GAME,
        FAIL_GAME,
        WIN_GAME
    }

    public class RefereeMechanic : MonoBehaviour
    {
        protected GameState _gameState = GameState.IN_GAME;

        public AvatarMechanic _scrAvatarMechanic;
        public CoreMechanics _scrCoreMechanics;

        private void Awake()
        {
            if (_scrAvatarMechanic != null)
            {
                _scrAvatarMechanic.SetRefereeMechanic = this;
            }
            if (_scrCoreMechanics == null)
            {
                _scrCoreMechanics = GetComponent<CoreMechanics>();
            }
        }

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

        #region GoalStateMechanics

        public virtual void StartMechanic()
        {
            if (_gameState == GameState.IN_GAME || _gameState == GameState.PAUSE_GAME)
            {
                if (_gameState == GameState.IN_GAME)
                {
                    _gameState = GameState.PAUSE_GAME;
                    Time.timeScale = 0.0f;
                }
                else if (_gameState == GameState.PAUSE_GAME)
                {
                    _gameState = GameState.IN_GAME;
                    Time.timeScale = 1.0f;
                }
            }
            if (_gameState == GameState.WIN_GAME)
            {
                NextLevel();
            }
            if (_gameState == GameState.FAIL_GAME)
            {
                RestartLevel();
            }
        }

        public virtual void SelectMechanic()
        {
            RestartLevel();
        }

        public virtual void FailedGoalMechanic()
        {
            _gameState = GameState.FAIL_GAME;
        }

        public virtual void AchievedGoalMechanic()
        {
            _gameState = GameState.WIN_GAME;
        }

        #endregion

        #region Getters

        public GameState GameState
        {
            get
            {
                return _gameState;
            }
        }

        public CoreMechanicDefinition GetCoreMechanicDefinition(CoreMechanicType value)
        {
            return _scrCoreMechanics.GetCoreMechanicDefinition(value);
        }

        #endregion

        #region SceneMethods

        protected void NextLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }

        protected void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        #endregion
    }
}