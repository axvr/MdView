using Markdig.Syntax.Inlines;

namespace MdView
{
    /// <summary>
    /// Data passed to <see cref="MdView.LinkHandler"/> on link click.
    /// </summary>
    public class LinkData
    {
        internal LinkData(LinkInline mdNode, string linkText)
        {
            Url = mdNode.Url;
            Title = mdNode.Title;
            Text = linkText;
        }

        /// <summary>
        /// The link URL to open.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The title of the link.
        /// </summary>
        ///
        /// <remarks>
        /// See: https://daringfireball.net/projects/markdown/syntax#link
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// [Link](https://example.com "This is the link title")
        /// </code>
        /// </example>
        public string Title { get; set; }

        /// <summary>
        /// The text of the link.
        /// </summary>
        ///
        /// <remarks>
        /// See: https://daringfireball.net/projects/markdown/syntax#link
        /// </remarks>
        ///
        /// <example>
        /// <code>
        /// [This is the link text](https://example.com)
        /// </code>
        /// </example>
        public string Text { get; set; }
    }
}
