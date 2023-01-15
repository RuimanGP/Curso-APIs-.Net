﻿namespace LinqSnippets.Models.DataModels;

internal class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public List<Comment>? Comments { get; set; }
}
