namespace AccountStorage.Clients.WebClients.Components.Configuration
{
    public class ColumnDefinition
    {
        public string DataField { get; set; }
        public string Caption { get; set; }
        public DataType DataType { get; set; }
        public string Format { get; set; }
        public Alignment Alignment { get; set; }

        public ColumnDefinition()
        {
            DataType = DataType.NotSet;
            Alignment = Alignment.NotSet;
        }
    }
}
