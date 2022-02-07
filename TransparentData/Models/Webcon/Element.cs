using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TransparentData.Models.Webcon
{
    public partial class Element
    {

        [JsonProperty("formFields")]
        public List<FormField> FormFields { get; set; }

        [JsonProperty("itemLists")]
        public List<ItemList> ItemLists { get; set; }

        [JsonProperty("comments")]
        public Comments Comments { get; set; }

    }

    public partial class Comments
    {
        [JsonProperty("newComment")]
        public string NewComment { get; set; }
    }

    public partial class FormField
    {

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("svalue")]
        public string Svalue { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class ItemList
    {

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("columns")]
        public List<Column> Columns { get; set; }

        [JsonProperty("rows")]
        public List<Row> Rows { get; set; }
    }

    public partial class Column
    {

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Row
    {
        [JsonProperty("cells")]
        public List<Cell> Cells { get; set; }
    }

    public partial class Cell
    {

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("svalue")]
        public string Svalue { get; set; }
    }

    public partial class Value
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}

