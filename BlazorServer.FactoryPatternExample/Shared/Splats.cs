using MudBlazor;
using System.Globalization;

namespace BlazorServer.FactoryPatternExample.Shared
{
    public static class Splats
    {
        public static Dictionary<string, object> CancelButton()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"button_cancel" },
                { "Variant",Variant.Filled },
                { "Color", Color.Error },
                { "StartIcon", Icons.Material.Filled.Cancel },
            };

            return attributes;
        }

        public static Dictionary<string, object> DataGrid(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"datagrid_{GenerateId(label)}" },
                { "SortMode", SortMode.Multiple },
                { "Filterable", true },
                { "FilterMode", DataGridFilterMode.Simple },
                { "FilterCaseSensitivity", DataGridFilterCaseSensitivity.CaseInsensitive },
                { "Dense", true },
                { "Striped", true },
            };

            return attributes;
        }

        public static string GenerateId(string label)
        {
            return label.ToLower(CultureInfo.CurrentCulture);
        }

        public static Dictionary<string, object> NewButton()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"button_new" },
                { "Variant",Variant.Filled },
                { "Color", Color.Success },
                { "StartIcon", Icons.Material.Filled.Add },
            };

                return attributes;
        }

        public static Dictionary<string, object> NumericRequired(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"numeric_{GenerateId(label)}" },
                { "Variant", Variant.Outlined },
                { "Required", true },
                { "RequiredError", $"{label} is required." },
                { "Label", label },
                { "Min", 0 },
            };

            return attributes;
        }

        public static Dictionary<string, object> PageHeader(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"header_{GenerateId(label)}" },
                { "Typo", Typo.h4 }
            };

            return attributes;
        }

        public static Dictionary<string, object> ResetButton()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"button_reset" },
                { "Variant",Variant.Filled },
                { "Color", Color.Warning },
                { "StartIcon", Icons.Material.Filled.Redo },
            };

            return attributes;
        }

        public static Dictionary<string, object> SaveButton()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"button_save" },
                { "Variant",Variant.Filled },
                { "Color", Color.Success },
                { "StartIcon", Icons.Material.Filled.Save },
            };

            return attributes;
        }

        public static Dictionary<string, object> SearchField()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", "text_search" },
                { "Placeholder", "Search" },
                { "Adornment", Adornment.Start },
                { "AdornmentIcon", Icons.Material.Filled.Search },
                { "IconSize", Size.Medium },
                { "Immediate", true },
            };

            return attributes;
        }

        public static Dictionary<string, object> SelectOptional(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"select_{GenerateId(label)}" },
                { "Variant", Variant.Outlined },
            };

            return attributes;
        }

        public static Dictionary<string, object> SelectRequired(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"select_{GenerateId(label)}" },
                { "Variant", Variant.Outlined },
                { "Required", true },
                { "RequiredError", $"{label} is required." },
            };

            return attributes;
        }

        public static Dictionary<string, object> TextRequired(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"text_{GenerateId(label)}" },
                { "Variant", Variant.Outlined },
                { "Required", true },
                { "RequiredError", $"{label} is required." },
                { "Label", label },
            };

            return attributes;
        }

        public static Dictionary<string, object> TextAreaRequired(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"textarea_{GenerateId(label)}" },
                { "Variant", Variant.Outlined },
                { "Required", true },
                { "RequiredError", $"{label} is required." },
                { "Label", label },
                { "Lines", 3 },
            };

            return attributes;
        }
    }
}
