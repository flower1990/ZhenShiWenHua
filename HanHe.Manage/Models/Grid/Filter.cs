using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using HanHe.Manage.Models.Helpers;

namespace HanHe.Manage.Models.Grid
{
    [DataContract]
    public class GridFilter
    {
        [DataMember]
        public string groupOp { get; set; }
        [DataMember]
        public Rule[] rules { get; set; }

        public static GridFilter Create(string jsonData)
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(GridFilter));
                System.IO.StringReader reader = new System.IO.StringReader(jsonData);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(jsonData));
                return serializer.ReadObject(ms) as GridFilter;
            }
            catch
            {
                return null;
            }
        }

        public static IQueryable<T> Filtring<T>(GridSettings grid, IQueryable<T> query)
        {
            if (grid.IsSearch)
            {
                //And
                if (grid.Where.groupOp == "AND")
                    foreach (var rule in grid.Where.rules)
                        query = query.Where<T>(
                            rule.field, rule.data,
                            (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op));
                else
                {
                    //Or
                    var temp = (new List<T>()).AsQueryable();
                    foreach (var rule in grid.Where.rules)
                    {
                        var t = query.Where<T>(
                        rule.field, rule.data,
                        (WhereOperation)StringEnum.Parse(typeof(WhereOperation), rule.op));
                        temp = temp.Concat<T>(t);
                    }
                    //remove repeating records
                    query = temp.Distinct<T>();
                }
            }
            return query;
        }
    }
}