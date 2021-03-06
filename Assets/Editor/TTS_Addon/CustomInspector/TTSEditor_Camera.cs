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
        PropertyField cFlags = new PropertyField(clearFlags) ;
        cFlags.BindProperty(clearFlags);
        cFlags.label = "Clear Flags";
        root.Add(cFlags);
        cFlags.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        backgroundColor = m_SerializedObject.FindProperty("m_BackGroundColor");
        ColorField bColor = new ColorField("backgroundColor");
        bColor.BindProperty(backgroundColor);
        bColor.label = "Background color";
        root.Add(bColor);
        bColor.RegisterCallback<FocusInEvent>(OnFocusInEventColor);
        bColor.RegisterCallback<ChangeEvent<Color>>(ChangeEventColor);

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

        orthographicSize = m_SerializedObject.FindProperty("orthographic size");
        FloatField sSize = new FloatField("orthographicSize");
        sSize.BindProperty(orthographicSize);
        sSize.label = "Ortographic Size";
        root.Add(sSize);
        sSize.RegisterCallback<FocusInEvent>(OnFocusInEventFloat);
        sSize.RegisterCallback<ChangeEvent<float>>(ChangeEventFloat);

        nearClippingPlane = m_SerializedObject.FindProperty("near clip plane");
        FloatField nClippin = new FloatField("nearClippingPlane");
        nClippin.BindProperty(nearClippingPlane);
        nClippin.label = "Near clipping plane";
        root.Add(nClippin);
        nClippin.RegisterCallback<FocusInEvent>(OnFocusInEventFloat);
        nClippin.RegisterCallback<ChangeEvent<float>>(ChangeEventFloat);

        farClippingPlane = m_SerializedObject.FindProperty("far clip plane");
        FloatField fClippin = new FloatField("farClippingPlane");
        fClippin.BindProperty(farClippingPlane);
        fClippin.label = "Far clipping plane";
        root.Add(fClippin);
        fClippin.RegisterCallback<FocusInEvent>(OnFocusInEventFloat);
        fClippin.RegisterCallback<ChangeEvent<float>>(ChangeEventFloat);

        normalizedViewPortRect = m_SerializedObject.FindProperty("m_NormalizedViewPortRect");
        RectField nViewPortRect = new RectField("normalizedViewPortRect");
        nViewPortRect.BindProperty(normalizedViewPortRect);
        nViewPortRect.label = "Normalized Viewport Rect";
        root.Add(nViewPortRect);
        nViewPortRect.RegisterCallback<FocusInEvent>(OnFocusInEventRect);
        nViewPortRect.RegisterCallback<ChangeEvent<Rect>>(ChangeEventRect);

        depth = m_SerializedObject.FindProperty("m_Depth");
        FloatField _depth = new FloatField("depth");
        _depth.BindProperty(depth);
        _depth.label = "Depth";
        root.Add(_depth);
        _depth.RegisterCallback<FocusInEvent>(OnFocusInEventFloat);
        _depth.RegisterCallback<ChangeEvent<float>>(ChangeEventFloat);

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
        Toggle oCulling = new Toggle("occlusionCulling");
        oCulling.BindProperty(occlusionCulling);
        oCulling.label = "Occlusion Culling";
        root.Add(oCulling);
        oCulling.RegisterCallback<FocusInEvent>(OnFocusInEventBool);
        oCulling.RegisterCallback<ChangeEvent<bool>>(ChangeEventToggle);

        HDR = m_SerializedObject.FindProperty("m_HDR");
        Toggle hdr = new Toggle("HDR");

        hdr.BindProperty(HDR);
        hdr.label = "HDR";
        root.Add(hdr);
        hdr.RegisterCallback<FocusInEvent>(OnFocusInEventBool);

        allowMSAA = m_SerializedObject.FindProperty("m_AllowMSAA");
        Toggle msaa = new Toggle("allowMSAA");

        msaa.BindProperty(allowMSAA);
        msaa.label = "Allow MSAA";
        root.Add(msaa);
        msaa.RegisterCallback<FocusInEvent>(OnFocusInEventBool);
        msaa.RegisterCallback<ChangeEvent<bool>>(ChangeEventToggle);

        allowDynamicResolution = m_SerializedObject.FindProperty("m_AllowDynamicResolution");
        Toggle aDynamicRes = new Toggle("allowDynamicResolution");
        aDynamicRes.BindProperty(allowDynamicResolution);
        aDynamicRes.label = "Allow Dynamic Resolution";
        root.Add(aDynamicRes);
        aDynamicRes.RegisterCallback<FocusInEvent>(OnFocusInEventBool);
        aDynamicRes.RegisterCallback<ChangeEvent<bool>>(ChangeEventToggle);

        targetDisplay = m_SerializedObject.FindProperty("m_TargetDisplay");
        PropertyField tDisplay = new PropertyField(targetDisplay);
        tDisplay.BindProperty(targetDisplay);
        tDisplay.label = "Target Display";
        root.Add(tDisplay);
        tDisplay.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);


        return root;
    }

    private void OnFocusInEventFloat(FocusInEvent evt)
    {

        FloatField field = evt.target as FloatField;
        InspectorTabController.currentValueAsString = field.value.ToString();
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        WindowsVoice.silence();

        InspectorTabController.currentElementSelected = "Camera";
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }
    private void ChangeEventFloat(ChangeEvent<float> evt)
    {
        FloatField field = evt.target as FloatField;
        InspectorTabController.currentValueAsString = field.value.ToString();
    }

    private void OnFocusInEventBool(FocusInEvent evt)
    {
        Toggle field = evt.target as Toggle;
        InspectorTabController.currentValueAsString = field.value.ToString();
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        WindowsVoice.silence();

        InspectorTabController.currentElementSelected = "Camera";
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }

    private void ChangeEventToggle(ChangeEvent<bool> evt)
    {
        Toggle field = evt.target as Toggle;
        InspectorTabController.currentValueAsString = field.value.ToString();
    }
    private void OnFocusInEventDropdown(FocusInEvent evt)
    {
        InspectorTabController.currentElementSelected = "Camera";
        InspectorTabController.currentValueAsString = "Dropdown Field not implemented";
       
    }

  
    private void OnFocusInEventRect(FocusInEvent evt)
    {
        RectField field = evt.target as RectField;
        InspectorTabController.currentValueAsString = "X = " + field.value.x + ", Y = " + field.value.y + ", Height = " + field.value.height + ", Width = " + field.value.width;
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        WindowsVoice.silence();

        InspectorTabController.currentElementSelected = "Camera";
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }

    private void ChangeEventRect(ChangeEvent<Rect> evt)
    {
        RectField field = evt.target as RectField;
        InspectorTabController.currentValueAsString = "X = " + field.value.x + ", Y = " + field.value.y + ", Height = " + field.value.height + ", Width = " + field.value.width;
    }
    private void OnFocusInEventObjectPicker(FocusInEvent evt)
    {
        InspectorTabController.currentElementSelected = "Camera";
        InspectorTabController.currentValueAsString = "Object Field not implemented";
    }
    private void OnFocusInEventColor(FocusInEvent evt)
    {
        ColorField field = evt.target as ColorField;
        InspectorTabController.currentValueAsString = "Red = " + field.value.r * 255 + ", Green = " + field.value.g * 255 + ", Blue = " + field.value.b * 255 + ", Alpha = " + field.value.a * 255;
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        WindowsVoice.silence();

        InspectorTabController.currentElementSelected = "Camera";
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }

    private void ChangeEventColor(ChangeEvent<Color> evt)
    {
        ColorField field = evt.target as ColorField;
        InspectorTabController.currentValueAsString = "Red = " + field.value.r * 255 + ", Green = " + field.value.g * 255 + ", Blue = " + field.value.b * 255 + ", Alpha = " + field.value.a * 255;
    }
}
