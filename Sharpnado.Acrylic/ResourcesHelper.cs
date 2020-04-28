using System;

using Xamarin.Forms;

namespace Sharpnado.Acrylic
{
    public static class ResourcesHelper
    {
        public const string PrimaryColor = nameof(PrimaryColor);

        public const string DynamicMaterialTheme = nameof(DynamicMaterialTheme);
        public const string DynamicBlurStyle = nameof(DynamicBlurStyle);

        public const string DynamicPrimaryColor = nameof(DynamicPrimaryColor);
        public const string DynamicSecondaryColor = nameof(DynamicSecondaryColor);

        public const string DynamicPrimaryOnBackgroundColor = nameof(DynamicPrimaryOnBackgroundColor);
        public const string DynamicSecondaryOnBackgroundColor = nameof(DynamicSecondaryOnBackgroundColor);

        public const string DynamicTextPrimaryColor = nameof(DynamicTextPrimaryColor);
        public const string DynamicTextSecondaryColor = nameof(DynamicTextSecondaryColor);
        public const string DynamicTextTernaryColor = nameof(DynamicTextTernaryColor);

        public const string DynamicHeaderTextColor = nameof(DynamicHeaderTextColor);

        public const string DynamicCornerRadius = nameof(DynamicCornerRadius);

        public const string DynamicIsVisible = nameof(DynamicIsVisible);

        public const string DynamicBackgroundColor = nameof(DynamicBackgroundColor);
        public const string DynamicBackgroundImageSource = nameof(DynamicBackgroundImageSource);

        public const string DynamicLabelAppsColor = nameof(DynamicLabelAppsColor);

        public static T GetResource<T>(string key)
        {
            if (Application.Current.Resources.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            throw new InvalidOperationException($"key {key} not found in the resource dictionary");
        }

        public static Color GetResourceColor(string key)
        {
            if (Application.Current.Resources.TryGetValue(key, out var value))
            {
                return (Color)value;
            }

            throw new InvalidOperationException($"key {key} not found in the resource dictionary");
        }

        public static void SetDynamicResource(string targetResourceName, string sourceResourceName)
        {
            if (!Application.Current.Resources.TryGetValue(sourceResourceName, out var value))
            {
                throw new InvalidOperationException($"key {sourceResourceName} not found in the resource dictionary");
            }

            Application.Current.Resources[targetResourceName] = value;
        }

        public static void SetDynamicResource<T>(string targetResourceName, T value)
        {
            Application.Current.Resources[targetResourceName] = value;
        }

        public static void SetAcrylic(bool isBlurEnabled)
        {
            if (isBlurEnabled)
            {
                SetDynamicResource(DynamicMaterialTheme, MaterialFrame.MaterialFrame.Theme.AcrylicBlur);
                SetDynamicResource(DynamicBackgroundColor, Color.Transparent);
                return;
            }
            
            SetDynamicResource(DynamicMaterialTheme, MaterialFrame.MaterialFrame.Theme.Acrylic);
            SetDynamicResource(DynamicBackgroundColor, "AcrylicSurface");
            SetDynamicResource(DynamicBackgroundImageSource, new FileImageSource());
            SetLightColors(false);
        }

        public static void SetBlurStyle(MaterialFrame.MaterialFrame.BlurStyle blurStyle)
        {
            switch (blurStyle)
            {
                case MaterialFrame.MaterialFrame.BlurStyle.Light:
                    SetDarkColors(false);
                    SetDynamicResource(
                        DynamicBackgroundImageSource,
                        new FileImageSource
                            {
                                File = Device.RuntimePlatform == Device.iOS ? "catalina_dark.jpg" : "bing_dark.jpg"
                            });
                    break;

                case MaterialFrame.MaterialFrame.BlurStyle.Dark:
                    SetDarkColors(true);
                    SetDynamicResource(
                        DynamicBackgroundImageSource,
                        new FileImageSource
                            {
                                File = Device.RuntimePlatform == Device.iOS
                                           ? "catalina_light.jpg"
                                           : "milky_light.jpg"
                            });
                    break;

                case MaterialFrame.MaterialFrame.BlurStyle.ExtraLight:
                    SetLightColors(true);
                    SetDynamicResource(
                        DynamicBackgroundImageSource,
                        new FileImageSource
                            {
                                File = Device.RuntimePlatform == Device.iOS
                                           ? "undersea_light.jpg"
                                           : "bing_light.jpg"
                            });
                    break;
            }

            SetDynamicResource(DynamicBlurStyle, blurStyle);
        }

        public static void SetLightColors(bool darkBackground)
        {
            SetDynamicResource(DynamicHeaderTextColor, "TextPrimaryColor");

            SetDynamicResource(DynamicPrimaryOnBackgroundColor, darkBackground ? "PrimaryDarkColor" : "PrimaryColor");
            SetDynamicResource(DynamicSecondaryOnBackgroundColor, darkBackground ? "SecondaryDarkColor" : "SecondaryColor");

            SetDynamicResource(DynamicPrimaryColor, "PrimaryColor");
            SetDynamicResource(DynamicSecondaryColor, "SecondaryColor");

            SetDynamicResource(DynamicTextPrimaryColor, "TextPrimaryColor");
            SetDynamicResource(DynamicTextSecondaryColor, "TextSecondaryColor");
            SetDynamicResource(DynamicTextTernaryColor, "TextTernaryColor");

            SetDynamicResource(DynamicLabelAppsColor, "LabelAppsColor");
        }

        public static void SetDarkColors(bool lightBackground)
        {
            SetDynamicResource(DynamicHeaderTextColor, "TextPrimaryDarkColor");

            SetDynamicResource(DynamicPrimaryOnBackgroundColor, lightBackground ? "PrimaryColor" : "PrimaryDarkColor");
            SetDynamicResource(DynamicSecondaryOnBackgroundColor, lightBackground ? "SecondaryColor" : "SecondaryDarkColor");

            SetDynamicResource(DynamicPrimaryColor, "PrimaryDarkColor");
            SetDynamicResource(DynamicSecondaryColor, "SecondaryDarkColor");

            SetDynamicResource(DynamicTextPrimaryColor, "TextPrimaryDarkColor");
            SetDynamicResource(DynamicTextSecondaryColor, "TextSecondaryDarkColor");
            SetDynamicResource(DynamicTextTernaryColor, "TextTernaryDarkColor");

            SetDynamicResource(DynamicLabelAppsColor, "LabelAppsDarkColor");
        }
    }
}
