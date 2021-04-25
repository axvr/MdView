# MdView for Xamarin.Forms

### *The flexible Markdown control for Xamarin.Forms.*

MdView is a highly customisable framework for rendering Markdown as native Xamarin.Forms components.

MdView's default controls are designed to be easily replaced with your own custom ones, to better match the design of your app and add additional functionality.

| Default Xamarin Theme | Dark Google Material Theme | Dynamic Editing of Markdown |
|---|---|---|
| ![][default] | ![][dark] | ![][edit] |

[default]: https://raw.githubusercontent.com/NumerousTechnology/MdView/fea2f790808a16189080bacfeb4909985cd558a1/MdView_Sample_Default.png
[dark]: https://github.com/NumerousTechnology/MdView/raw/fea2f790808a16189080bacfeb4909985cd558a1/MdView_Sample_Dark.gif
[edit]: https://github.com/NumerousTechnology/MdView/raw/fea2f790808a16189080bacfeb4909985cd558a1/MdView_Sample_Edit.gif

These examples come from the MdView sample app (found within this repository) which you are encouraged to try out and copy source code from.


## Usage

*Note: MdView is currently in beta and backwards incompatible changes may happen.  Any backwards incompatible changes will be mentioned in the [release notes](https://github.com/NumerousTechnology/MdView/releases).*


### Getting started

Install the [MdView package from NuGet.org](https://www.nuget.org/packages/MdView) in the shared project of your app.  Once installed add the namespace to your XAML file and start using `MdView`.

```xaml
<ContentPage ...
             xmlns:md="clr-namespace:MdView;assembly=MdView"
             ...>
    <ScrollView>
        <md:MdView Markdown="Hello **world**!" />
    </ScrollView>
</ContentPage>
```


### Customise

_WIP._


## Contributions

Contributions are welcome! If you find a bug please report it and if you want a feature please report it or submit a pull request.

### Built with

- [MarkdownView](https://github.com/dotnet-ad/MarkdownView) — from which this package was forked.
- [Markdig](https://github.com/lunet-io/markdig) —  used for Markdown parsing.


## Legal

- Copyright © 2021, [Numerous Technology](https://numerous.app).
- Copyright © 2020, [Alex Vear](https://alexvear.com).
- Copyright © 2017, [Aloïs Deniel](http://aloisdeniel.github.io).

The MdView library and source code is available under the terms of the [_Expat_
(_MIT_)][MIT] licence.  All documentation text and sample app code are
dedicated to the public domain.  The MdView logo is available under the [_CC
BY-SA 4.0_][CC] licence.  A more in depth legal description can be found in the
accompanying [`LICENCE`][Licence] file.


[CC0]: https://creativecommons.org/publicdomain/zero/1.0/
[CC]:  https://creativecommons.org/licenses/by-sa/4.0/
[MIT]: https://directory.fsf.org/wiki/License:MIT
[Licence]: https://github.com/NumerousTechnology/MdView/blob/master/LICENCE
