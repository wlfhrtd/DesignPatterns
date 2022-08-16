using System.Text;

namespace Builder
{
    public class InventoryReport
    {
        public string TitleSection;

        public string DimensionsSection;

        public string LogisticsSection;


        public override string ToString()
        {
            // btw StringBuilder is example of Fluent Builder Builder pattern variation
            return new StringBuilder()
                .AppendLine(TitleSection)
                .AppendLine(DimensionsSection)
                .AppendLine(LogisticsSection)
                .ToString();
        }
    }
}
