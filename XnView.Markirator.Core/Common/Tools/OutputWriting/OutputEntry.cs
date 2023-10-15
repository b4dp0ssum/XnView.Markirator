namespace XnView.Markirator.Core.Common.Tools.OutputWriting;

public record OutputEntry(DateTime? Timestamp, int Step, string Title, string? Description = null);