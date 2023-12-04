//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Inputs/CameraActionsMap.inputactions
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

public partial class @CameraActionsMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CameraActionsMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraActionsMap"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""f6af01a9-e4cc-4981-8e71-fe570f4bfbb8"",
            ""actions"": [
                {
                    ""name"": ""MouseMoveX"",
                    ""type"": ""Value"",
                    ""id"": ""a4e119b5-a464-4976-a907-a7e32c5a64e1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseMoveY"",
                    ""type"": ""Value"",
                    ""id"": ""c6e279c0-a6fa-4e7c-b643-3ca15ee9dfcb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MoveX"",
                    ""id"": ""4583b4ee-88f7-4e02-aefe-e140495d56a2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a509965c-492d-4400-97f8-dfc7a7896bc3"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d210f355-25f3-4abe-a293-817938f926c9"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""MoveY"",
                    ""id"": ""03d801e3-4f0d-4a3d-b303-ba452f53e9fa"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMoveY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b083c60b-8833-436c-a790-10eb0815d88b"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3a8a3373-7e60-4981-8ac8-0cccc0808c0b"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_MouseMoveX = m_Camera.FindAction("MouseMoveX", throwIfNotFound: true);
        m_Camera_MouseMoveY = m_Camera.FindAction("MouseMoveY", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();
    private readonly InputAction m_Camera_MouseMoveX;
    private readonly InputAction m_Camera_MouseMoveY;
    public struct CameraActions
    {
        private @CameraActionsMap m_Wrapper;
        public CameraActions(@CameraActionsMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseMoveX => m_Wrapper.m_Camera_MouseMoveX;
        public InputAction @MouseMoveY => m_Wrapper.m_Camera_MouseMoveY;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void AddCallbacks(ICameraActions instance)
        {
            if (instance == null || m_Wrapper.m_CameraActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CameraActionsCallbackInterfaces.Add(instance);
            @MouseMoveX.started += instance.OnMouseMoveX;
            @MouseMoveX.performed += instance.OnMouseMoveX;
            @MouseMoveX.canceled += instance.OnMouseMoveX;
            @MouseMoveY.started += instance.OnMouseMoveY;
            @MouseMoveY.performed += instance.OnMouseMoveY;
            @MouseMoveY.canceled += instance.OnMouseMoveY;
        }

        private void UnregisterCallbacks(ICameraActions instance)
        {
            @MouseMoveX.started -= instance.OnMouseMoveX;
            @MouseMoveX.performed -= instance.OnMouseMoveX;
            @MouseMoveX.canceled -= instance.OnMouseMoveX;
            @MouseMoveY.started -= instance.OnMouseMoveY;
            @MouseMoveY.performed -= instance.OnMouseMoveY;
            @MouseMoveY.canceled -= instance.OnMouseMoveY;
        }

        public void RemoveCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICameraActions instance)
        {
            foreach (var item in m_Wrapper.m_CameraActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CameraActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    public interface ICameraActions
    {
        void OnMouseMoveX(InputAction.CallbackContext context);
        void OnMouseMoveY(InputAction.CallbackContext context);
    }
}
