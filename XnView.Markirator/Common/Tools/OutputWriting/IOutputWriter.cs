namespace XnView.Markirator.App.Common.Tools.OutputWriting;

internal interface IOutputWriter
{
    int CurrentLevel { get; set; }

    int TabMultiplier { get; }

    void Writeline(string line, bool addTimestamp = true);
}
