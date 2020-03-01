# MdView *for Xamarin.Forms*

*The flexible Markdown control for Xamarin.Forms.*

[![MdView CI](https://github.com/axvr/MdView/workflows/MdView%20CI/badge.svg)](https://github.com/axvr/MdView/actions?query=workflow%3A%22MdView+CI%22)

*Note: this package is still pre-alpha. It will **not** be available on [NuGet](https://nuget.org/) until `v1.0`*

## Gallery

![Light theme](Documentation/Screenshot.png)

## Introduction

Compared to a majority of solutions, MarkdownView will render every component as **a native Xamarin.Forms view instead of via an HTML backend.** The Markdown is directly translated from a syntax tree to a hierarchy of Xamarin.Forms views; no HTML is being produced at all (hurray)!

This will produce a more reactive user interface, at the cost of rendering functionalities *(at the moment though!)*.

## Limitations

Unfortunately, Xamarin.Forms string rendering has some limitations...

- **Inlined images aren't supported** (*Xamarin.Forms formatted strings doesn't support inlined views*) : They will be displayed after the block they are referenced from.
- **Links are only clickable at a leaf block level**  (*Xamarin.Forms formatted strings doesn't support span user interactions*) : if a leaf block contains more than one link, the user is prompted. This is almost a feature since text may be too small to be enough precise! ;)

## Contributions

Contributions are welcome! If you find a bug please report it and if you want a feature please report it or submit a pull request.

## Thanks

- [MarkdownView](https://github.com/dotnet-ad/MarkdownView) — from which this package was forked.
- [Markdig](https://github.com/lunet-io/markdig) —  used for Markdown parsing.

## License

This package is licenced under the **MIT licence**. A full copy of the licence text can be found in the [`LICENSE`](https://github.com/axvr/MdView/blob/master/LICENSE) file provided.

- Copyright © 2020 [Alex Vear](https://axvr.io)
- Copyright © 2017 [Aloïs Deniel](http://aloisdeniel.github.io)
