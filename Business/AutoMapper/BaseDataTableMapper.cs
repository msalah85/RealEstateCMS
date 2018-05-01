using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public abstract class BaseDataTableMapper<T> : IDataTableMappper<T> where T:new()
    {
        public  List<T> ToList(DataTable _DataTable) 
        {
            var dataList = new List<T>();
            DataRow dataRow;
            for (int rows = 0; rows < _DataTable.Rows.Count; rows++)
            {
                dataRow = _DataTable.Rows[rows];
               T newObject = new T();
                MapObject(newObject, dataRow);
                dataList.Add(newObject);
            }
                return dataList;
        }


        protected abstract T MapObject(T newObject, DataRow _DataRow);

        
    }
}
