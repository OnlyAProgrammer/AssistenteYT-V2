namespace Assistente.Grammatics
{
    internal sealed class GrammarPoint
    {
        internal GrammarPoint(string[] inputs, GrammarSubType grammarSubType)
        {
            Inputs = inputs;
            GrammarSubType = grammarSubType;
        }

        internal string[] Inputs { get; }
        internal GrammarSubType GrammarSubType { get; }
    }
}
