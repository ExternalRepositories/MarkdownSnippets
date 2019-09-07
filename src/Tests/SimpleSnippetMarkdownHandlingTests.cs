﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using ApprovalTests;
using MarkdownSnippets;
using Xunit;
using Xunit.Abstractions;

public class SimpleSnippetMarkdownHandlingTests :
    XunitApprovalBase
{
    [Fact]
    public void AppendGroup()
    {
        var builder = new StringBuilder();
        var snippets = new List<Snippet> {Snippet.Build(1, 2, "theValue", "thekey", "thelanguage", "thePath")};
        using (var writer = new StringWriter(builder))
        {
            SimpleSnippetMarkdownHandling.AppendGroup("key1", snippets, writer.WriteLine);
        }

        Approvals.Verify(builder.ToString());
    }

    public SimpleSnippetMarkdownHandlingTests(ITestOutputHelper output) : base(output)
    {
    }
}