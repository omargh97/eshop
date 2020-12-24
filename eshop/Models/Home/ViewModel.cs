using eshop.DAL;
using eshop.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace eshop.Models.Home
{
    public class ViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        dbEshopEntities context = new dbEshopEntities();
        public IPagedList<Tbl_Product> ListOfProducts { get; set; }

        public ViewModel CreateModel(string search, int pageSize, int? page)
        {

            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IPagedList<Tbl_Product> data = context.Database.SqlQuery<Tbl_Product>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize);
            return new ViewModel
            {
                ListOfProducts = data
            };
        }
    }
}