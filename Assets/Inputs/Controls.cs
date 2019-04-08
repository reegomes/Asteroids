// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Controls.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class Controls : InputActionAssetReference
{
    public Controls()
    {
    }
    public Controls(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Spaceship
        m_Spaceship = asset.GetActionMap("Spaceship");
        m_Spaceship_Fire = m_Spaceship.GetAction("Fire");
        m_Spaceship_Movesemuso = m_Spaceship.GetAction("Move sem uso");
        m_Spaceship_Teclas = m_Spaceship.GetAction("Teclas");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Spaceship = null;
        m_Spaceship_Fire = null;
        m_Spaceship_Movesemuso = null;
        m_Spaceship_Teclas = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Spaceship
    private InputActionMap m_Spaceship;
    private InputAction m_Spaceship_Fire;
    private InputAction m_Spaceship_Movesemuso;
    private InputAction m_Spaceship_Teclas;
    public struct SpaceshipActions
    {
        private Controls m_Wrapper;
        public SpaceshipActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire { get { return m_Wrapper.m_Spaceship_Fire; } }
        public InputAction @Movesemuso { get { return m_Wrapper.m_Spaceship_Movesemuso; } }
        public InputAction @Teclas { get { return m_Wrapper.m_Spaceship_Teclas; } }
        public InputActionMap Get() { return m_Wrapper.m_Spaceship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(SpaceshipActions set) { return set.Get(); }
    }
    public SpaceshipActions @Spaceship
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new SpaceshipActions(this);
        }
    }
}
