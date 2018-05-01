using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Business.Enums;

namespace Business.Globalization
{
    public class GlobalizationManager
    {
        public GlobalizationManager()
        {

            this.Items = new Dictionary<string, List<TranslatedItem>>();
        }

        public GlobalizationManager(DataTable table)
        {
            this.SetDataTable(table);
        }
        public GlobalizationManager(DataSet _langDS, string direction)
        {
            this.SetDataSet(_langDS, direction);

        }

        public void SetDataSet(DataSet _langDS, string direction)
        {

            try
            {

                this.Items = new Dictionary<string, List<TranslatedItem>>();
                if (_langDS != null)
                {
                    //for (int index = 1; index < _langDS.Tables.Count; index++)
                    //{
                    var table = _langDS.Tables[0];
                    //if (table.TableName == "UserLangInfo")
                    //{

                    //    string _langDirection = (from n in table.AsEnumerable()
                    //                             select n.Field<string>("LangDirection")).FirstOrDefault().ToString();

                    //    if (_langDirection.ToLower() == "rtl")
                    //        this.IsUserLang_RTL = true;
                    //    else
                    //        this.IsUserLang_RTL = false;

                    //}
                    //else
                    //{
                    List<TranslatedItem> _TranslatedItems = new List<TranslatedItem>();
                    _TranslatedItems = (from n in table.AsEnumerable()
                                        select new TranslatedItem() { id = n.Field<string>("id"), c = n.Field<string>("c") }).ToList<TranslatedItem>();

                    if (direction == "RTL")
                        this.IsUserLang_RTL = true;
                    else
                        this.IsUserLang_RTL = false;

                    this.Items.Add(table.TableName, _TranslatedItems);
                    //}
                    // }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void SetDataTable(DataTable _langTable)
        {
            try
            {

                this.Items = new Dictionary<string, List<TranslatedItem>>();
                if (_langTable != null)
                {
                    var table = _langTable;
                    List<TranslatedItem> _TranslatedItems = new List<TranslatedItem>();
                    _TranslatedItems = (from n in table.AsEnumerable()
                                        select new TranslatedItem() { id = n.Field<string>("id"), c = n.Field<string>("c") }).ToList<TranslatedItem>();

                    this.Items.Add(table.TableName, _TranslatedItems);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private Dictionary<string, List<TranslatedItem>> Items { get; set; }
        public bool IsUserLang_RTL { get; set; }

        public List<TranslatedItem> GetModule(Enum_LangModule Module)
        {
            if (Items.ContainsKey(Module.ToString()))
            {
                return Items[Module.ToString()];
            }
            return null;
        }

        public Dictionary<string, List<TranslatedItem>> GetAllModules()
        {
            return Items;
        }

        public string GetTranslatedText(string Original, Enum_LangModule Module, string ID)
        {
            string TextTranslated = "";
            if (!this.IsUserLang_RTL) TextTranslated = Original;
            else
            {
                List<TranslatedItem> ModuleItems = Items["MaskanWeb"];
                if (ModuleItems != null)
                {
                    TranslatedItem _TranslatedItem = ModuleItems.FirstOrDefault(T => T.id == ID);
                    if (_TranslatedItem != null)
                    {
                        TextTranslated = _TranslatedItem.c;
                    }
                }
            }
            return TextTranslated;
        }
    }
}
