using Microsoft.Maui.Controls.Compatibility;

// ReSharper disable UnusedMember.Global
namespace tshreader.Behaviors;

public class FirstAndLastChildBehavior
{
    #region Bindable Properties

    public static readonly BindableProperty IdentifyFirstAndLastChildProperty = BindableProperty.CreateAttached(
        "IdentifyFirstAndLastChild",
        typeof(bool),
        typeof(FirstAndLastChildBehavior),
        false,
        BindingMode.OneWay,
        null,
        IdentifyFirstAndLastChildPropertyChanged);

    public static readonly BindableProperty IsFirstChildProperty = BindableProperty.CreateAttached(
        "IsFirstChild",
        typeof(bool),
        typeof(FirstAndLastChildBehavior),
        false);

    public static readonly BindableProperty IsLastChildProperty = BindableProperty.CreateAttached(
        "IsLastChild",
        typeof(bool),
        typeof(FirstAndLastChildBehavior),
        false);

    #endregion

    public static void UpdateChildFirstLastProperties(Layout<View> layout)
    {
        var children = layout.Children;
        for (var i = 0; i < children.Count; ++i)
        {
            var child = children[i];
            SetIsFirstChild(child, i == 0);
            SetIsLastChild(child, i == children.Count - 1);
        }
    }

    #region IdentifyFirstAndLastChild Attached Property

    public static bool GetIdentifyFirstAndLastChild(Layout<View> layout)
    {
        return (bool)layout.GetValue(IdentifyFirstAndLastChildProperty);
    }

    public static void SetIdentifyFirstAndLastChild(Layout<View> layout, bool value)
    {
        layout.SetValue(IdentifyFirstAndLastChildProperty, value);
    }

    private static void IdentifyFirstAndLastChildPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var layout = (Layout<View>)bindable;
        layout.LayoutChanged += (_, _) => UpdateChildFirstLastProperties(layout);
    }

    #endregion

    #region IsFirstChild Attached Property

    public static bool GetIsFirstChild(View obj)
    {
        return (bool)obj.GetValue(IsFirstChildProperty);
    }

    public static void SetIsFirstChild(View obj, bool value)
    {
        obj.SetValue(IsFirstChildProperty, value);
    }

    #endregion

    #region IsLastChild Attached Property

    public static bool GetIsLastChild(View obj)
    {
        return (bool)obj.GetValue(IsLastChildProperty);
    }

    public static void SetIsLastChild(View obj, bool value)
    {
        obj.SetValue(IsLastChildProperty, value);
    }

    #endregion
}
