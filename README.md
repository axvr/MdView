# MdView for Xamarin.Forms

***UNMAINTAINED.  MdView is stable and shouldn't require much (if any) maintenance.  If you would like to maintain it please [contact me](https://www.alexvear.com/contact).***

MdView is a highly customisable Markdown control for Xamarin.Forms.  With MdView you can render Markdown such that it perfectly matches the design and behaviour of your app.

| Xamarin Theme | Custom Dark Theme |
|---|---|
| <img src="https://raw.githubusercontent.com/axvr/MdView/fea2f790808a16189080bacfeb4909985cd558a1/MdView_Sample_Default.png" width="270"/> | <img src="https://github.com/axvr/MdView/raw/fea2f790808a16189080bacfeb4909985cd558a1/MdView_Sample_Dark.gif" width="270"/> |


## Usage

*Note: MdView is currently in beta so backwards incompatible changes may happen.  Backwards incompatible changes will be mentioned in the [release notes](https://github.com/axvr/MdView/releases).*


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

MdView is entirely based around [data templates](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/templates/data-templates/).  Each Markdown element (e.g. paragraphs, images) has a corresponding data template which that MdView will use to render the Markdown.

Replacing and configuring a template is easy.

```xaml
<ContentPage ...
             xmlns:md="clr-namespace:MdView;assembly=MdView"
             xmlns:mdt="clr-namespace:MdView.Templates;assembly=MdView"
             ...>
    <ScrollView>
        <md:MdView Markdown="# Heading 1">
            <!--
                Replace the default "Heading1Template" with a "MdView.Templates.Heading1"
                template configured with centred text.
            -->
            <md:MdView.Heading1Template>
                <mdt:Heading1 HorizontalTextAlignment="Center" />
            </md:MdView.Heading1Template>
        </md:MdView>
    </ScrollView>
</ContentPage>
```

The templates provided with MdView are highly customisable, however you may want to create your own custom ones to better integrate into your application or add new features.  The best way to see how to create custom templates is to view/copy the source code of the [default templates](https://github.com/axvr/MdView/tree/master/MdView/Templates) and the [example templates](https://github.com/axvr/MdView/tree/master/MdView.Sample/MdView.Sample/Controls) in the sample project provided.

**Note** that you may want to create a custom "Markdown" control that sets default styles to use across your application.  An example of this can be seen in the [sample project](https://github.com/axvr/MdView/blob/master/MdView.Sample/MdView.Sample/Controls/MdView.xaml).


## Legal

- Copyright © 2020–2021, [Alex Vear](https://www.alexvear.com).
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
[Licence]: https://github.com/axvr/MdView/blob/master/LICENCE
