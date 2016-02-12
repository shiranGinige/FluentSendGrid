using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SendgridFluent
{
    public class SgHeader
    {
        public static SgHeader Initialize()
        {
            var substitionsDictionary = new Dictionary<string, string[]>();
            var categoriesArray = new string[1] ;
            var sgHeader = new SgHeader()
            {
                sub = substitionsDictionary,
                //Category = categoriesArray,
                filters = new Filters() { templates = new Templates() { settings = new Settings() { enabled = 1, template_id = string.Empty } } }
            };

            return sgHeader;
        }
        //public string[] To { get; set; }
        //public string[] Category { get; set; }
        public IDictionary<string, string[]> sub { get; set; } 

        public Filters filters { get; set; }

        public string JsonSerialize()
        {
           return JsonConvert.SerializeObject(this);
        }
    }
}