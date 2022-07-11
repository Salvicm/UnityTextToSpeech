using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

[CanEditMultipleObjects, CustomEditor(typeof(Rigidbody))]
public class TTSEditor_Rigidbody : Editor
{
    Rigidbody rigidbody;
    SerializedProperty m_Constraints;
    SerializedProperty m_Mass;
    SerializedProperty m_Drag;
    SerializedProperty m_AngularDrag;

    SerializedProperty m_ImplicitCom;
    SerializedProperty m_CenterOfMass;
    SerializedProperty m_ImplicitTensor;
    SerializedProperty m_InertiaTensor;
    SerializedProperty m_InertiaRotation;

    SerializedProperty m_UseGravity;
    SerializedProperty m_IsKinematic;
    SerializedProperty m_Interpolate;
    SerializedProperty m_CollisionDetection;
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new VisualElement();
        
        rigidbody = target as Rigidbody;
        SerializedObject m_SerializedObject = new SerializedObject(rigidbody);

        m_Mass = m_SerializedObject.FindProperty("m_Mass");
        FloatField _mass = new FloatField("m_Mass");
        _mass.BindProperty(m_Mass);
        _mass.label = "Mass";
        root.Add(_mass);
        _mass.RegisterCallback<FocusInEvent>(OnFocusInEventFloat);
        _mass.RegisterCallback<ChangeEvent<float>>(ChangeEventFloat);

        m_Drag = m_SerializedObject.FindProperty("m_Drag");
        FloatField _drag = new FloatField("m_Drag");
        _drag.BindProperty(m_Drag);
        _drag.label = "Drag";
        root.Add(_drag);
        _drag.RegisterCallback<FocusInEvent>(OnFocusInEventFloat);
        _drag.RegisterCallback<ChangeEvent<float>>(ChangeEventFloat);

        m_AngularDrag = m_SerializedObject.FindProperty("m_AngularDrag");
        FloatField _angularDrag = new FloatField("m_AngularDrag");
        _angularDrag.BindProperty(m_AngularDrag);
        _angularDrag.label = "Angular Drag";
        root.Add(_angularDrag);
        _angularDrag.RegisterCallback<FocusInEvent>(OnFocusInEventFloat);
        _angularDrag.RegisterCallback<ChangeEvent<float>>(ChangeEventFloat);

        m_UseGravity = m_SerializedObject.FindProperty("m_UseGravity");
        Toggle _useGravity = new Toggle("m_UseGravity");
        _useGravity.BindProperty(m_UseGravity);
        _useGravity.label = "Use Gravity";
        root.Add(_useGravity);
        _useGravity.RegisterCallback<FocusInEvent>(OnFocusInEventBool);
        _useGravity.RegisterCallback<ChangeEvent<bool>>(ChangeEventToggle);

        m_IsKinematic = m_SerializedObject.FindProperty("m_IsKinematic");
        Toggle _isKinematic = new Toggle("m_IsKinematic");
        _isKinematic.BindProperty(m_IsKinematic);
        _isKinematic.label = "Is Kinematic";
        root.Add(_isKinematic);
        _isKinematic.RegisterCallback<FocusInEvent>(OnFocusInEventBool);
        _isKinematic.RegisterCallback<ChangeEvent<bool>>(ChangeEventToggle);

        m_Interpolate = m_SerializedObject.FindProperty("m_Interpolate");
        PropertyField _interpolate = new PropertyField(m_Interpolate);
        _interpolate.BindProperty(m_Interpolate);
        _interpolate.label = "Interpolate";
        root.Add(_interpolate);
        _interpolate.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        m_CollisionDetection = m_SerializedObject.FindProperty("m_CollisionDetection");
        PropertyField _collisionDetection = new PropertyField(m_CollisionDetection);
        _collisionDetection.BindProperty(m_CollisionDetection);
        _collisionDetection.label = "Collision Detection";
        root.Add(_collisionDetection);
        _collisionDetection.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        m_Constraints = m_SerializedObject.FindProperty("m_Constraints");
        PropertyField _constrains = new PropertyField(m_Constraints);
        _constrains.BindProperty(m_Constraints);
        _constrains.label = "Constraints";
        root.Add(_constrains);
        _constrains.RegisterCallback<FocusInEvent>(OnFocusInEventDropdown);

        m_ImplicitCom = m_SerializedObject.FindProperty("m_ImplicitCom");
        m_CenterOfMass = m_SerializedObject.FindProperty("m_CenterOfMass");
        m_ImplicitTensor = m_SerializedObject.FindProperty("m_ImplicitTensor");
        m_InertiaTensor = m_SerializedObject.FindProperty("m_InertiaTensor");
        m_InertiaRotation = m_SerializedObject.FindProperty("m_InertiaRotation");

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

        InspectorTabController.currentElementSelected = "Rigidbody";
        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }

    private void OnFocusInEventBool(FocusInEvent evt)
    {
        Toggle field = evt.target as Toggle;
        InspectorTabController.currentElementSelected = "Rigidbody";
        InspectorTabController.currentValueAsString = field.value.ToString();
        if (field.label != InspectorTabController.prevSelectedLabel)
            InspectorTabController.prevSelectedLabel = field.label;
        else return;
        WindowsVoice.silence();

        WindowsVoice.speak(InspectorTabController.prevSelectedLabel);
    }

    private void OnFocusInEventDropdown(FocusInEvent evt)
    {
        InspectorTabController.currentElementSelected = "Rigidbody";
        InspectorTabController.currentValueAsString = "Dropdown Field not implemented";
    }

    private void ChangeEventFloat(ChangeEvent<float> evt)
    {
        // Desconozco porque esto está dando errores
        return;
        FloatField field = evt.target as FloatField;
        InspectorTabController.currentValueAsString = field.value.ToString();
        WindowsVoice.silence();
        WindowsVoice.speak(field.value.ToString());
    }

    private void ChangeEventToggle(ChangeEvent<bool> evt)
    {
        Toggle field = evt.target as Toggle;
        InspectorTabController.currentValueAsString = field.value.ToString();
    }
    private void ChangeEventRect(ChangeEvent<Rect> evt)
    {
        RectField field = evt.target as RectField;
        InspectorTabController.currentValueAsString = "X = " + field.value.x + ", Y = " + field.value.y + ", Height = " + field.value.height + ", Width = " + field.value.width;
    }
    private void ChangeEventColor(ChangeEvent<Color> evt)
    {
        ColorField field = evt.target as ColorField;
        InspectorTabController.currentValueAsString = "Red = " + field.value.r * 255 + ", Green = " + field.value.g * 255 + ", Blue = " + field.value.b * 255 + ", Alpha = " + field.value.a * 255;
    }
}


