# Lucide Icons for AvaloniaUI
[![NuGet Version](https://img.shields.io/nuget/v/LucideAvalonia)](https://www.nuget.org/packages/LucideAvalonia)
[![GitHub License](https://img.shields.io/github/license/MarwanFr/LucideAvaloniaUI)](https://github.com/MarwanFr/LucideAvaloniaUI/blob/main/LICENSE)

![Lucide Icons for AvaloniaUI](https://raw.githubusercontent.com/MarwanFr/LucideAvaloniaUI/main/image/Banner.webp)

## Over 1480 icons for AvaloniaUI

### What is it?

**Lucide Icons for AvaloniaUI** is a library that allows you to integrate over 1400 modern and elegant icons into your AvaloniaUI projects. This library offers a wide range of icons to enhance the user interface of your applications.

### What is it for?

This library is ideal for:
- Extensive Collection: Access to over 1400 high-quality icons.
- Scalability: Icons are vector-based, ensuring they look sharp at any size.
- Ease of Use: Simple integration with AvaloniaUI projects.
- Open Source: Free to use and modify, fostering community collaboration and improvement.

### Installation

> [!WARNING]
> This library is compatible only with AvaloniaUI version 11.1.0-beta1 or higher. It does not support earlier versions.

To install the library, you can use NuGet with the following command:

```sh
dotnet add package LucideAvalonia
```

### Usage

To use the Lucide Icons in your AvaloniaUI project, add the following namespace declaration to the header of your AXAML file:
```axaml
xmlns:lucideAvalonia="clr-namespace:LucideAvalonia;assembly=LucideAvalonia"
```

Integrating Lucide Icons into your AvaloniaUI project is straightforward. Below is an example demonstrating how to add a YouTube icon to your AXAML file:

```axaml
<lucideAvalonia:Lucide Icon="Youtube" StrokeBrush="Red" StrokeThickness="1.5" Width="22" Height="22"/>
```

You can customize the appearance of the icons using various properties:

- Icon: Specifies the name of the icon.
- StrokeBrush: Defines the color of the icon stroke.
- StrokeThickness: Sets the thickness of the icon stroke.
- Width and Height: Adjust the size of the icon.

### Contribution

We welcome contributions from the community to help improve and expand this library. If you encounter any issues or have suggestions, please open an issue or submit a pull request on our GitHub repository.

### Credit
This project is made possible thanks to the following:

- [AvaloniaUI](https://www.avaloniaui.net): The versatile and powerful UI framework.
- [Lucide](https://www.lucide.dev): The source of these beautifully designed icons.
