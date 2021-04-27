# MdView for Xamarin.Forms

### The flexible Markdown control for Xamarin.Forms.

MdView is a highly customisable Markdown control for Xamarin.Forms.  With MdView you can render Markdown such that it perfectly matches the design and behaviour of your app.

| Xamarin Theme | Custom Dark Theme |
|---|---|
| <img src="https://raw.githubusercontent.com/NumerousTechnology/MdView/fea2f790808a16189080bacfeb4909985cd558a1/MdView_Sample_Default.png" width="270"/> | <img src="https://github.com/NumerousTechnology/MdView/raw/fea2f790808a16189080bacfeb4909985cd558a1/MdView_Sample_Dark.gif" width="270"/> |


## Usage

*Note: MdView is currently in beta so backwards incompatible changes may happen.  Backwards incompatible changes will be mentioned in the [release notes](https://github.com/NumerousTechnology/MdView/releases).*


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

## Legal

- Copyright © 2021, [Numerous Technology](https://numerous.app).
- Copyright © 2020, [Alex Vear](https://alexvear.com).
- Copyright © 2017, [Aloïs Deniel](https://aloisdeniel.github.io).

The MdView library and source code is available under the terms of the [_Expat_
(_MIT_)][MIT] licence.  All documentation text and sample app code are
dedicated to the public domain.  The MdView logo is available under the [_CC
BY-SA 4.0_][CC] licence.  A more in depth legal description can be found in the
accompanying [`LICENCE`][Licence] file.

MdView is a fork of [MarkdownView](https://github.com/dotnet-ad/MarkdownView).


[CC0]: https://creativecommons.org/publicdomain/zero/1.0/
[CC]:  https://creativecommons.org/licenses/by-sa/4.0/
[MIT]: https://directory.fsf.org/wiki/License:MIT
[Licence]: https://github.com/NumerousTechnology/MdView/blob/master/LICENCE
