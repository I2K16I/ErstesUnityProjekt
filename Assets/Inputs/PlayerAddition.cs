//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Inputs/PlayerAddition.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerAddition: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerAddition()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerAddition"",
    ""maps"": [
        {
            ""name"": ""PlayerCustom"",
            ""id"": ""7f3e171c-bfda-4722-bd74-9706c1357844"",
            ""actions"": [
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""9577aef1-a35e-42d7-93d9-04ea8e341603"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""d61ef8df-214a-41b3-a4ec-9c389c21e7e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9f2fceb5-b86e-4e68-984d-81902ebb023a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d44cde14-834b-4ad1-b612-3a309c6cc8a0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerCustom
        m_PlayerCustom = asset.FindActionMap("PlayerCustom", throwIfNotFound: true);
        m_PlayerCustom_Menu = m_PlayerCustom.FindAction("Menu", throwIfNotFound: true);
        m_PlayerCustom_Interact = m_PlayerCustom.FindAction("Interact", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerCustom
    private readonly InputActionMap m_PlayerCustom;
    private List<IPlayerCustomActions> m_PlayerCustomActionsCallbackInterfaces = new List<IPlayerCustomActions>();
    private readonly InputAction m_PlayerCustom_Menu;
    private readonly InputAction m_PlayerCustom_Interact;
    public struct PlayerCustomActions
    {
        private @PlayerAddition m_Wrapper;
        public PlayerCustomActions(@PlayerAddition wrapper) { m_Wrapper = wrapper; }
        public InputAction @Menu => m_Wrapper.m_PlayerCustom_Menu;
        public InputAction @Interact => m_Wrapper.m_PlayerCustom_Interact;
        public InputActionMap Get() { return m_Wrapper.m_PlayerCustom; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerCustomActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerCustomActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerCustomActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerCustomActionsCallbackInterfaces.Add(instance);
            @Menu.started += instance.OnMenu;
            @Menu.performed += instance.OnMenu;
            @Menu.canceled += instance.OnMenu;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
        }

        private void UnregisterCallbacks(IPlayerCustomActions instance)
        {
            @Menu.started -= instance.OnMenu;
            @Menu.performed -= instance.OnMenu;
            @Menu.canceled -= instance.OnMenu;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
        }

        public void RemoveCallbacks(IPlayerCustomActions instance)
        {
            if (m_Wrapper.m_PlayerCustomActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerCustomActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerCustomActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerCustomActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerCustomActions @PlayerCustom => new PlayerCustomActions(this);
    public interface IPlayerCustomActions
    {
        void OnMenu(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}