using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CanEditMultipleObjects, CustomEditor(typeof(Camera))]
public class TTSEditor_Camera : Editor
{
    Camera camera;
    #region properties
    public SerializedProperty clearFlags { get; private set; }
    public SerializedProperty backgroundColor { get; private set; }
    public SerializedProperty normalizedViewPortRect { get; private set; }
    internal SerializedProperty projectionMatrixMode { get; private set; }
    public SerializedProperty iso { get; private set; }
    public SerializedProperty shutterSpeed { get; private set; }
    public SerializedProperty aperture { get; private set; }
    public SerializedProperty focusDistance { get; private set; }
    public SerializedProperty focalLength { get; private set; }
    public SerializedProperty bladeCount { get; private set; }
    public SerializedProperty curvature { get; private set; }
    public SerializedProperty barrelClipping { get; private set; }
    public SerializedProperty anamorphism { get; private set; }
    public SerializedProperty sensorSize { get; private set; }
    public SerializedProperty lensShift { get; private set; }
    public SerializedProperty gateFit { get; private set; }
    public SerializedProperty verticalFOV { get; private set; }
    public SerializedProperty orthographic { get; private set; }
    public SerializedProperty orthographicSize { get; private set; }
    public SerializedProperty depth { get; private set; }
    public SerializedProperty cullingMask { get; private set; }
    public SerializedProperty renderingPath { get; private set; }
    public SerializedProperty occlusionCulling { get; private set; }
    public SerializedProperty targetTexture { get; private set; }
    public SerializedProperty HDR { get; private set; }
    public SerializedProperty allowMSAA { get; private set; }
    public SerializedProperty allowDynamicResolution { get; private set; }
    public SerializedProperty stereoConvergence { get; private set; }
    public SerializedProperty stereoSeparation { get; private set; }
    public SerializedProperty nearClippingPlane { get; private set; }
    public SerializedProperty farClippingPlane { get; private set; }
    public SerializedProperty fovAxisMode { get; private set; }

    public SerializedProperty targetDisplay { get; private set; }

    public SerializedProperty targetEye { get; private set; }
    #endregion
    
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();

        camera = target as Camera;
        SerializedObject m_SerializedObject = new SerializedObject(camera);

        clearFlags = m_SerializedObject.FindProperty("m_ClearFlags");
        PropertyField cFlags = new PropertyField(clearFlags);
        cFlags.BindProperty(clearFlags);
        cFlags.label = "Clear Flags";
        root.Add(cFlags);
        cFlags.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        backgroundColor = m_SerializedObject.FindProperty("m_BackGroundColor");
        PropertyField bColor = new PropertyField(backgroundColor);
        bColor.BindProperty(backgroundColor);
        bColor.label = "Background color";
        root.Add(bColor);
        bColor.RegisterCallback<FocusInEvent>(OnFocusInEventColor);

        cullingMask = m_SerializedObject.FindProperty("m_CullingMask");
        PropertyField cMask = new PropertyField(cullingMask);
        cMask.BindProperty(cullingMask);
        cMask.label = "Culling Mask";
        root.Add(cMask);
        cMask.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        projectionMatrixMode = m_SerializedObject.FindProperty("m_projectionMatrixMode");
        PropertyField pMatrix = new PropertyField(projectionMatrixMode);
        pMatrix.BindProperty(projectionMatrixMode);
        pMatrix.label = "Projection Matrix Mode";
        root.Add(pMatrix);
        pMatrix.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        sensorSize = m_SerializedObject.FindProperty("m_SensorSize");
        IntegerField sSize = new IntegerField("sensorSize");
        sSize.BindProperty(sensorSize);
        sSize.label = "Sensor Size";
        root.Add(sSize);
        sSize.RegisterCallback<FocusInEvent>(OnFocusInEventInteger);

        nearClippingPlane = m_SerializedObject.FindProperty("near clip plane");
        PropertyField nClippin = new PropertyField(nearClippingPlane);
        nClippin.BindProperty(nearClippingPlane);
        nClippin.label = "Near clipping plane";
        root.Add(nClippin);
        nClippin.RegisterCallback<FocusInEvent>(OnFocusInEventInteger);

        farClippingPlane = m_SerializedObject.FindProperty("far clip plane");
        PropertyField fClippin = new PropertyField(farClippingPlane);
        fClippin.BindProperty(farClippingPlane);
        fClippin.label = "Far clipping plane";
        root.Add(fClippin);
        fClippin.RegisterCallback<FocusInEvent>(OnFocusInEventInteger);

        normalizedViewPortRect = m_SerializedObject.FindProperty("m_NormalizedViewPortRect");
        PropertyField nViewPortRect = new PropertyField(normalizedViewPortRect);
        nViewPortRect.BindProperty(normalizedViewPortRect);
        nViewPortRect.label = "Normalized Viewport Rect";
        root.Add(nViewPortRect);
        nViewPortRect.RegisterCallback<FocusInEvent>(OnFocusInEventVector4);

        depth = m_SerializedObject.FindProperty("m_Depth");
        PropertyField _depth = new PropertyField(depth);
        _depth.BindProperty(depth);
        _depth.label = "Depth";
        root.Add(_depth);
        _depth.RegisterCallback<FocusInEvent>(OnFocusInEventInteger);

        renderingPath = m_SerializedObject.FindProperty("m_RenderingPath");
        PropertyField rPath = new PropertyField(renderingPath);
        rPath.BindProperty(renderingPath);
        rPath.label = "Rendering Path";
        root.Add(rPath);
        rPath.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        targetTexture = m_SerializedObject.FindProperty("m_TargetTexture");
        PropertyField tTexture = new PropertyField(targetTexture);
        tTexture.BindProperty(targetTexture);
        tTexture.label = "Target Texture";
        root.Add(tTexture);
        tTexture.RegisterCallback<FocusInEvent>(OnFocusInEventObjectPicker);

        occlusionCulling = m_SerializedObject.FindProperty("m_OcclusionCulling");
        PropertyField oCulling = new PropertyField(occlusionCulling);
        oCulling.BindProperty(occlusionCulling);
        oCulling.label = "Occlusion Culling";
        root.Add(oCulling);
        oCulling.RegisterCallback<FocusInEvent>(OnFocusInEventBool);

        HDR = m_SerializedObject.FindProperty("m_HDR");
        PropertyField hdr = new PropertyField(HDR);
        hdr.BindProperty(HDR);
        hdr.label = "HDR";
        root.Add(hdr);
        hdr.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        allowMSAA = m_SerializedObject.FindProperty("m_AllowMSAA");
        PropertyField msaa = new PropertyField(allowMSAA);
        msaa.BindProperty(allowMSAA);
        msaa.label = "Allow MSAA";
        root.Add(msaa);
        msaa.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        allowDynamicResolution = m_SerializedObject.FindProperty("m_AllowDynamicResolution");
        PropertyField aDynamicRes = new PropertyField(allowDynamicResolution);
        aDynamicRes.BindProperty(allowDynamicResolution);
        aDynamicRes.label = "Allow Dynamic Resolution";
        root.Add(aDynamicRes);
        aDynamicRes.RegisterCallback<FocusInEvent>(OnFocusInEventBool);

        targetDisplay = m_SerializedObject.FindProperty("m_TargetDisplay");
        PropertyField tDisplay = new PropertyField(targetDisplay);
        tDisplay.BindProperty(targetDisplay);
        tDisplay.label = "Target Display";
        root.Add(tDisplay);
        tDisplay.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        targetEye = m_SerializedObject.FindProperty("m_TargetEye");
        PropertyField tEye = new PropertyField(targetEye);
        tEye.BindProperty(targetEye);
        tEye.label = "Target Eye";
        root.Add(tEye);
        tEye.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);



        iso = m_SerializedObject.FindProperty("m_Iso");
        shutterSpeed = m_SerializedObject.FindProperty("m_ShutterSpeed");
        aperture = m_SerializedObject.FindProperty("m_Aperture");
        focusDistance = m_SerializedObject.FindProperty("m_FocusDistance");
        focalLength = m_SerializedObject.FindProperty("m_FocalLength");
        bladeCount = m_SerializedObject.FindProperty("m_BladeCount");
        curvature = m_SerializedObject.FindProperty("m_Curvature");
        barrelClipping = m_SerializedObject.FindProperty("m_BarrelClipping");
        anamorphism = m_SerializedObject.FindProperty("m_Anamorphism");
        lensShift = m_SerializedObject.FindProperty("m_LensShift");
        gateFit = m_SerializedObject.FindProperty("m_GateFitMode");
        nearClippingPlane = m_SerializedObject.FindProperty("near clip plane");
        farClippingPlane = m_SerializedObject.FindProperty("far clip plane");
        verticalFOV = m_SerializedObject.FindProperty("field of view");
        fovAxisMode = m_SerializedObject.FindProperty("m_FOVAxisMode");
        orthographic = m_SerializedObject.FindProperty("orthographic");
        orthographicSize = m_SerializedObject.FindProperty("orthographic size");

        stereoConvergence = m_SerializedObject.FindProperty("m_StereoConvergence");
        stereoSeparation = m_SerializedObject.FindProperty("m_StereoSeparation");

        return root;
    }

    private void OnFocusInEventInteger(FocusInEvent evt)
    {
        IntegerField field = evt.target as IntegerField;
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        //InspectorTabController.currentValueAsString = vector3Field.RegisterValueChangeCallback;
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }

    private void OnFocusInEventBool(FocusInEvent evt)
    {
        IntegerField field = evt.target as IntegerField;
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        //InspectorTabController.currentValueAsString = vector3Field.RegisterValueChangeCallback;
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }

    private void OnFocusInEventDropdown(FocusInEvent evt)
    {
        IntegerField field = evt.target as IntegerField;
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        //InspectorTabController.currentValueAsString = vector3Field.RegisterValueChangeCallback;
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }

    private void OnFocusInEventVector4(FocusInEvent evt)
    {
        IntegerField field = evt.target as IntegerField;
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        //InspectorTabController.currentValueAsString = vector3Field.RegisterValueChangeCallback;
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }
    private void OnFocusInEventObjectPicker(FocusInEvent evt)
    {
        IntegerField field = evt.target as IntegerField;
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        //InspectorTabController.currentValueAsString = vector3Field.RegisterValueChangeCallback;
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }
    private void OnFocusInEventColor(FocusInEvent evt)
    {
        IntegerField field = evt.target as IntegerField;
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        //InspectorTabController.currentValueAsString = vector3Field.RegisterValueChangeCallback;
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }
}