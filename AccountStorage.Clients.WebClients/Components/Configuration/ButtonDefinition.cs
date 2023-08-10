using Microsoft.AspNetCore.Components;

namespace AccountStorage.Clients.WebClients.Components.Configuration
{
    public class ButtonDefinition
    {
        public string Name { get; set; }

        public Action HandleOnclick { get; set; }

        public string CssClass { get; set; }
    }
}
