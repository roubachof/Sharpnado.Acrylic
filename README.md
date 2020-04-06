# Sharpnado Acrylic

Where **Sharpnado** is experimenting Acrylic effects.

<table>
	<thead>
		<tr>
			<th>Android</th>
			<th>iOS</th>
		</tr>
	</thead>
	<tbody>
		<tr>
			<td><img src="__Docs__\acrylic_android.png" width="320" /></td>
			<td><img src="__Docs__\acrylic_ios.png" width="360" /></td>
		</tr>
  </tbody>
</table>

`MaterialFrame.xaml` file:

```xml
<ResourceDictionary xmlns="http://xamarin.com/schemas/2014/forms"
                    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                    xmlns:rv="clr-namespace:Sharpnado.Presentation.Forms.RenderedViews;assembly=Sharpnado.Presentation.Forms">

    <ResourceDictionary.MergedDictionaries>
        <ResourceDictionary Source="Colors.xaml" />
    </ResourceDictionary.MergedDictionaries>

    <Style TargetType="rv:MaterialFrame">
        <Setter Property="MaterialTheme" Value="Acrylic" />
        <Setter Property="Margin" Value="5, 5, 5, 10" />
        <Setter Property="Padding" Value="20,15" />
        <Setter Property="CornerRadius" Value="10" />
        <Setter Property="LightThemeBackgroundColor" Value="{StaticResource AcrylicFrameBackgroundColor}" />
    </Style>

</ResourceDictionary>
```

`Color.xaml` file:

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<?xaml-comp compile="true" ?>

<ResourceDictionary xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

    <Color x:Key="AcrylicSurface">#E6E6E6</Color>

    <Color x:Key="AcrylicFrameBackgroundColor">#F1F1F1</Color>

    <Color x:Key="AccentColor">#00E000</Color>

    <Color x:Key="PrimaryColor">Black</Color>
    <Color x:Key="SecondaryColor">#60000000</Color>
    <Color x:Key="TernaryColor">#30000000</Color>

    <Color x:Key="TextPrimaryColor">Black</Color>
    <Color x:Key="TextSecondaryColor">#60000000</Color>
    <Color x:Key="TextTernaryColor">#40000000</Color>

</ResourceDictionary>
```

Component used:

  * [``MaterialFrame``](https://github.com/roubachof/Sharpnado.Presentation.Forms)