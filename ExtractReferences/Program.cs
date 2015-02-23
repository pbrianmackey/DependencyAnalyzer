using ExtractReferences.Prolog;

namespace ExtractReferences
{
    class Program
    {
        static void Main(string[] args)
        {
            var facts = new GenerateProlog();
            facts.Generate(GlobalData.Solutions);
            facts.CreateKnowledgeBase();
        }
    }
}
