using Business.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services.Models
{
    public class propertyViewModel
    {
        [NonSqlParameter]
        public int PropertyID { get; set; }

        public DateTime CreationDate { get; set; }

        public int CountryID { get; set; }

        public int CityID { get; set; }

        public int ResidanceID { get; set; }

        public int StreetID { get; set; }

        public string LocationLat { get; set; }

        public string LocationLang { get; set; }

        public int ContactPersonID { get; set; }

        public int AddedByUserID { get; set; }

        public bool Active { get; set; }

        public string PropertyTitle { get; set; }

        public string Description { get; set; }

        public string Area { get; set; }

        public int AreaTypeID { get; set; }

        public decimal Price { get; set; }

        public int PriceTypeID { get; set; }

        public int BedRooms { get; set; }

        public int AdditionalRooms { get; set; }

        public int Bathrooms { get; set; }

        public int Balconies { get; set; }

        public int Floor { get; set; }

        public int FurnitureTypeID { get; set; }

        public int PropertyTypeID { get; set; }

        public int ProjectTypeID { get; set; }

        public int OwnershipTypeID { get; set; }


    }
}